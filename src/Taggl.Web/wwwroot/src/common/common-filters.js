function sanitizeHtml($sce) {
    // TODO: ng annotate
    return html => {
        return $sce.trustAsHtml(html);
    };
}

function momentFormat() {
    return (date, format) => moment(date).format(format);
}

function momentCommonDateFormat() {
    return date => moment(date).format('DD-MM-YYYY');
}

function momentCommonDateTimeFormat() {
    return date => moment(date).format('DD-MM-YYYY, h:mma');
}

function momentFromNow() {
    return date => moment(date).fromNow();
}

function momentFormatTodayOrDate() {
    return date => {
        var isToday = moment(date).isSame(new Date(), "day");
        if (isToday) {
            return moment(date).format('h:mm A');
        } else {
            return moment(date).format('MMM. D');
        }
    };
}

let commonFilters = angular.module('rr.common.filters', [])
    .filter('tglSanitizeHtml', sanitizeHtml)
    .filter('tglMomentFormat', momentFormat)
    .filter('tglMomentCommonDateFormat', momentCommonDateFormat)
    .filter('tglMomentCommonDateTimeFormat', momentCommonDateTimeFormat)
    .filter('tglMomentFromNow', momentFromNow)
    .filter('tglMomentFormatTodayOrDate', momentFormatTodayOrDate)
    .name;

export { commonFilters };


