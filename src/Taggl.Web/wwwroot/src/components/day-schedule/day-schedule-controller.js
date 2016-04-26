import { groupBy } from 'lodash';

import { paths } from '/src/paths';
import { Injectable } from './../../utility/injectable';
import { LoadStatus, createLoadStatusContainer } from './../../utility/load-status';

import { CreateShiftController } from './create-shift-controller';

export class DayScheduleController extends Injectable {
    static get $inject() {
        return ['$uibModal', 'TglLoggingService', 'TglApiInterfaceFactory'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);
        this.shiftScheduleApi = this.TglApiInterfaceFactory.createApiInterface('shiftSchedule');

        this.date = moment(parseInt(this.timestamp, 10)).startOf('day');

        this.shifts = [];
        this.shiftDataLoadStatus = createLoadStatusContainer(LoadStatus.Loading);
        this.shiftScheduleApi.list(this.date.toDate(), {
            model: this.shifts,
            loadStatusContainer: this.shiftDataLoadStatus
        });
    }

    addShift() {
        let shifts = this.shifts;
        this.$uibModal.open({
            controller: CreateShiftController,
            controllerAs: 'ctrl',
            templateUrl: `${paths.components}day-schedule/create-shift.html`,
            resolve: {
                date: this.date
            }
        }).result.then(shift => {
            if (shift) {
                shifts.push(shift);
            }
        });
    }
}