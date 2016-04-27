'use strict';

import * as angular from 'angular';

import { Injectable } from './../../utility/injectable';
import { LoadStatus, createLoadStatusContainer } from './../../utility/load-status';

export class ShiftDetailsController extends Injectable {
    static get $inject() {
        return ['$timeout', '$uibModal', 'TglLoggingService', 'TglApiInterfaceFactory'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);
        this.shiftScheduleApi = this.TglApiInterfaceFactory.createApiInterface('shiftSchedule');

        this.shift = {};
        this.shiftDataLoadStatus = createLoadStatusContainer(LoadStatus.Loading);
        this.shiftScheduleApi.get(this.shiftScheduleId, {
            model: this.shift,
            loadStatusContainer: this.shiftDataLoadStatus
        });

        const MINIMUM_LOAD_TIME = 1000;
        this.$timeout(() => this.showLoadingCompleted = true, MINIMUM_LOAD_TIME);
    }

    isLoaded() {
        return this.shiftDataLoadStatus.value === 3 && this.showLoadingCompleted;
    }

    getShiftEndTime() {
        return moment(this.shift.fromDate).add(this.shift.durationMinutes, 'minutes');
    }

    openEditShift() {
        let self = this;
        this.$uibModal.open({
            controller: ($uibModalInstance) => ({
                closeModal: () => {
                    $uibModalInstance.close();
                }
            }),
            controllerAs: 'ctrl',
            template: `
                <tgl-modal-base-directive modal-title="Edit Shift">
                    <tgl-shift-form shift-schedule-id="${this.shift.id}" on-save="ctrl.closeModal()" on-cancel="ctrl.closeModal()"></tgl-shift-form>
                </tgl-modal-base-directive>
            `
        }).result.then(shift => {
            angular.merge(self.shift, shift);
        });
    }

    openComments() {
        let self = this;
        this.$uibModal.open({
            controller: ($uibModalInstance) => ({
                closeModal: () => {
                    $uibModalInstance.close();
                }
            }),
            controllerAs: 'ctrl',
            template: `
                <tgl-modal-base-directive modal-title="Comments">
                    <tgl-shift-comments shift-id="${this.shift.id}"></gl-shift-comments>
                    <div>
                        <div class="pull-right">
                            <a href="javascript:void(0)" ng-click="ctrl.closeModal()">Close</a>
                        </div>
                    </div>
                </tgl-modal-base-directive>
            `
        }).result.then(shift => {
            angular.merge(self.shift, shift);
        });
    }
}