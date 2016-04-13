import { Injectable } from './../../utility/injectable';
import * as ArrayUtility  from './../../utility/array-utility';
import * as GuidUtility  from './../../utility/guid-utility';

export class ProfessionalityFormController extends Injectable {
    static get $inject() {
        return ['TglLoggingService', 'TglApiInterfaceFactory'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);
        this.professionalityApi = this.TglApiInterfaceFactory.createApiInterface('professionality');

        let self = this;
        this.professionalityApi.get().then(professionality => {
            self.masterExpertise = professionality.expertise;
            self.expertise = angular.copy(self.masterExpertise);
        });
    }

    filterJobTagResults(results) {
        let filteredResults = results.filter(j => !this.expertiseExists(j.name));
        return filteredResults;
    }

    isExpertiseSaved(expertise) {
        return !GuidUtility.isEmpty(expertise.id);
    }

    selectJobTag(jobTag) {
        if (jobTag && !this.expertiseExists(jobTag.name)) {
            this.expertise.push({
                jobTagId: jobTag.id,
                jobTagName: jobTag.name
            });
        }
    }

    createJobTag(jobTagName) {
        if (jobTagName && !this.expertiseExists(jobTagName)) {
            this.expertise.push({ jobTagName });
        }
    }

    expertiseExists(jobTagName) {
        return this.expertise.findIndex(e => e.jobTagName === jobTagName) >= 0;
    }

    removeExpertise(expertise) {
        ArrayUtility.remove(this.expertise, expertise);
    }

    save() {

    }
}