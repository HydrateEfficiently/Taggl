import { Injectable } from './../../utility/injectable';
import { SearchSource } from './../search/search';

export class AddShiftController extends Injectable {
    static get $inject() {
        return ['$uibModalInstance', 'day', 'TglLoggingService', 'TglApiInterfaceFactory'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);
        this.shiftScheduleApi = this.TglApiInterfaceFactory.createApiInterface('shiftSchedule');

        this.shiftSchedule = {};
        this.shiftTypeSearchSource = SearchSource.ShiftTypes;
        this.gymSearchSource = SearchSource.Gyms;
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

    save() {
        let data = angular.copy(this.shiftSchedule);
        let fromTimeMoment = moment(data.fromTime);
        let fromDateMoment = moment(this.day);
        fromDateMoment.add(fromTimeMoment.get('hours'), 'hours');
        fromDateMoment.add(fromTimeMoment.get('minutes'), 'minutes');
        data.fromDate = fromDateMoment.toDate();
        delete data.fromTime;

        let $uibModalInstance = this.$uibModalInstance;
        this.shiftScheduleApi.create(data, { 
            model: this.shiftSchedule
        }).then(result => {
            $uibModalInstance.close(result);
        });
    }

    close() {
        this.$uibModalInstance.close();
    }
}