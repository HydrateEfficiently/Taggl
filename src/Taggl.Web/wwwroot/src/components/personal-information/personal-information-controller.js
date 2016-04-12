import { Injectable } from './../../utility/injectable';

export class PersonalInformationController extends Injectable {
    static get $inject() {
        return ['$timeout', 'TglLoggingService', 'TglApiInterfaceFactory'];
    }

    constructor(...deps) {
        super(...deps);

        this.logger = this.TglLoggingService.createLogger(this.constructor.name);
        this.accountApi = this.TglApiInterfaceFactory.createApiInterface('account');

        this.personalInformation = {};
        this.personalInformationMaster = {};

        if (this.initialModelJson) {
            this.personalInformationMaster = angular.copy(JSON.parse(this.initialModelJson));
            this.personalInformation = angular.copy(this.personalInformationMaster);
            this.logger.debug('initial model ', this.personalInformation);
        }

        let self = this;
        this.$timeout(() => {
            self.isMasterValid = self.form.$valid;
            if (!self.isMasterValid) {
                self.isEditing = true;
            }
        });
    }

    edit() {
        this.isEditing = true;
    }

    cancel() {
        this.personalInformation = angular.copy(this.personalInformationMaster);
        this.isEditing = false;
    }

    save() {
        let self = this;
        if (this.form.$valid) {
            this.accountApi.updatePersonalInformation(this.personalInformation)
                .then(() => {
                    self.isEditing = false;
                    self.isMasterValid = true;
                    self.personalInformationMaster = angular.copy(self.personalInformation);
                });
        } else {
            this.form.$error.forEach(field => {
                field.forEach(errorField => {
                    errorField.$setTouched();
                });
            });
        }
    }

}