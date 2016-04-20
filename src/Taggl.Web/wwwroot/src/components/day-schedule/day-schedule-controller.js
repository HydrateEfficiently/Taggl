import { groupBy } from 'lodash';
import { Injectable } from './../../utility/injectable';
import { paths } from '/src/paths';
import { AddShiftController } from './add-shift-controller';

export class DayScheduleController extends Injectable {
    static get $inject() {
        return ['$uibModal', 'TglLoggingService'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);

        this.startOfDay = moment(parseInt(this.timestamp, 10))
            .startOf('day').toDate().getTime();

        this.shifts =  [
            {
                shiftType: {
                    id: 1,
                    name: 'Box Fit'
                },
                location: 'LA Fitness Marlyebone',
                date: parseInt(this.timestamp),
                durationMinutes: 1
            }
        ];
    }

    addShift() {
        this.$uibModal.open({
            controller: AddShiftController,
            controllerAs: 'ctrl',
            templateUrl: `${paths.components}day-schedule/add-shift.html`,
            resolve: {
                day: this.startOfDay
            }
        });
    }

    getShiftEndTime(shift) {
        return moment(shift.date).add(shift.durationMinutes, 'minutes');
    }
}

export { DayScheduleController };