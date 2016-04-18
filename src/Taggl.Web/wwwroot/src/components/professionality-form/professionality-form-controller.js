import { Injectable } from './../../utility/injectable';
import * as ArrayUtility  from './../../utility/array-utility';
import * as GuidUtility  from './../../utility/guid-utility';
import { SearchSource } from './../search/search';

export class ProfessionalityFormController extends Injectable {
    static get $inject() {
        return ['TglLoggingService', 'TglApiInterfaceFactory', 'TglSessionService'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);
        this.professionalityApi = this.TglApiInterfaceFactory.createApiInterface('professionality');

        this.professionality = {};
        this.professionalityMaster = {};
        this.professionalityApi.get({ 
            models: [
                this.professionality,
                this.professionalityMaster
            ]
        });
        this.searchSource = SearchSource.ShiftTypes;
    }

    filterShiftTypeResults(results) {
        let filteredResults = results.filter(j => !this.expertiseExists(j.name));
        return filteredResults;
    }

    selectShiftType(shiftType) {
        if (shiftType && !this.expertiseExists(shiftType.name)) {
            this.professionality.expertise.push({
                shiftTypeId: shiftType.id,
                shiftTypeName: shiftType.name,
                shouldDelete: false
            });
        }
    }

    createShiftType(shiftTypeName) {
        if (shiftTypeName && !this.expertiseExists(shiftTypeName)) {
            this.professionality.expertise.push({
                shiftTypeName,
                shouldDelete: false
            });
        }
    }

    expertiseExists(shiftTypeName) {
        return this.professionality.expertise.findIndex(e => e.shiftTypeName === shiftTypeName) >= 0;
    }

    deleteExpertise(expertise) {
        if (this.isExpertiseSaved(expertise)) {
            expertise.shouldDelete = true;
        } else {
            ArrayUtility.remove(this.professionality.expertise, expertise);
        }
    }

    undoDeleteExpertise(expertise) {
        expertise.shouldDelete = false;
    }

    isExpertiseSaved(expertise) {
        return !GuidUtility.isEmpty(expertise.id);
    }

    isExpertisedDeleted(expertise) {
        return expertise.shouldDelete;
    }

    edit() {
        this.isEditing = true;
    }

    cancel() {
        this.professionality = angular.copy(this.professionalityMaster);
        this.isEditing = false;
    }

    save() {
        let self = this;
        let updateRequest = angular.copy(this.professionality);
        let expertiseToDelete = updateRequest.expertise.filter(e => e.shouldDelete);
        expertiseToDelete.forEach(e => ArrayUtility.remove(updateRequest.expertise, e));
        this.professionalityApi.update(updateRequest, { 
            models: [
                this.professionality,
                this.professionalityMaster
            ]
        }).then(() => self.isEditing = false);
    }

    _onProfessionalityUpdated(professionality) {
        this.professionalityMaster = professionality;
        this.professionality = angular.copy(professionality);
    }
}