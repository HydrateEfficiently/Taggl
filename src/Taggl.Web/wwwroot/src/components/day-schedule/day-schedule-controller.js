import { groupBy } from 'lodash';
import { Injectable } from './../../utility/injectable';
import { paths } from '/src/paths';
import { AddShiftController } from './add-shift-controller';

export class DayScheduleController extends Injectable {
    static get $inject() {
        return ['$uibModal', 'TglLoggingService', 'TglApiInterfaceFactory'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);
        this.shiftScheduleApi = this.TglApiInterfaceFactory.createApiInterface('shiftSchedule');

        this.startOfDay = moment(parseInt(this.timestamp, 10))
            .startOf('day').toDate().getTime();
        this.startOfDayDate = moment(parseInt(this.timestamp, 10))
            .startOf('day').toDate();

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

        this.shiftScheduleApi.list(this.startOfDayDate, {
            model: this.shifts
        });
    }

    addShift() {
        let shifts = this.shifts;
        this.$uibModal.open({
            controller: AddShiftController,
            controllerAs: 'ctrl',
            templateUrl: `${paths.components}day-schedule/add-shift.html`,
            resolve: {
                day: this.startOfDay
            }
        }).result.then(shift => shifts.push(shift));
    }
}

export { DayScheduleController };