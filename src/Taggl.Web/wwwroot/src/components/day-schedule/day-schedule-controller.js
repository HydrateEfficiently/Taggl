import { Injectable } from './../../utility/injectable';
import { LoadStatus, createLoadStatusContainer } from './../../utility/load-status';

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
            resolve: {
                date: this.date
            },
            controller: ($uibModalInstance, date) => ({
                date,
                closeModal: (result) => {
                    $uibModalInstance.close(result);
                }
            }),
            controllerAs: 'ctrl',
            template: `
                <tgl-modal-base-directive modal-title="Add Shift">
                    <div class="mb-md">Add a new shift on {{ ctrl.date | tglMomentCommonDateFormat }}.</div>
                    <tgl-shift-form date="ctrl.date" on-save="ctrl.closeModal(result)" on-cancel="ctrl.closeModal()"></tgl-shift-form>
                </tgl-modal-base-directive>
            `
        }).result.then(shift => {
            if (shift) {
                shifts.push(shift);
            }
        });
    }
}