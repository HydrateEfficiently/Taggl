import { Injectable } from './../../utility/injectable';
import * as GuidUtility from './../../utility/guid-utility';
import { LoadStatus, createLoadStatusContainer } from './../../utility/load-status';
import { SearchSource } from './../search/search';

export class ShiftFormController extends Injectable {
    static get $inject() {
        return ['TglLoggingService', 'TglApiInterfaceFactory', '$scope'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);
        this.shiftScheduleApi = this.TglApiInterfaceFactory.createApiInterface('shiftSchedule');

        let shiftExists = !GuidUtility.isEmpty(this.shiftScheduleId);
        let self = this;
        
        this.SearchSource = SearchSource;

        this.shiftSchedule = {};
        this.shiftDataLoadStatus = createLoadStatusContainer(LoadStatus.Loaded);
        this.saveButtonText = shiftExists ? 'Edit' : 'Add';

        if (shiftExists) {
            this.shiftDataLoadStatus.value = LoadStatus.Loading;
            this.shiftScheduleApi.get(this.shiftScheduleId, {
                model: this.shiftSchedule,
                loadStatusContainer: this.shiftDataLoadStatus
            }).then(shift => {
                self.shiftSchedule.fromTime = new Date(shift.fromDate);
            });
        } else {
            this.shiftSchedule.fromDate = this.date;
        }
    }

    isLoaded() {
        return this.shiftDataLoadStatus.value === LoadStatus.Loaded;
    }

    selectShiftType(shiftType) {
        this.shiftSchedule.shiftTypeName = shiftType.name;
        this.shiftSchedule.shiftTypeId = shiftType.id;
    }

    createShiftType(shiftTypeName) {
        this.shiftSchedule.shiftTypeName = shiftTypeName;
    }

    selectGym(gym) {
        this.shiftSchedule.gymName = gym.name;
        this.shiftSchedule.gymId = gym.id;
    }

    createGym(gymName) {
        this.shiftSchedule.gymName = gymName;
    }

    cancel() {
        if (this.onCancel) {
            this.onCancel();
        }
    }

    save() {
        let self= this;
        let apiAction = GuidUtility.isEmpty(this.shiftScheduleId) ? 'create' : 'update';
        this.shiftScheduleApi[apiAction](this.shiftSchedule)
            .then(result => {
                if (self.onSave) {
                    self.onSave({ result });
                }
            });
    }

    _getPostData() {
        let data = angular.copy(this.shiftSchedule);
        let fromTimeMoment = moment(data.fromTime);
        let fromDateMoment = moment(this.day);
        fromDateMoment.add(fromTimeMoment.get('hours'), 'hours');
        fromDateMoment.add(fromTimeMoment.get('minutes'), 'minutes');
        data.fromDate = fromDateMoment.toDate();
        delete data.fromTime;
        return data;
    }
}