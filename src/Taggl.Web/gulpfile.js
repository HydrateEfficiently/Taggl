/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    less = require("gulp-less"),
    sass = require("gulp-sass"),
    print = require("gulp-print"),
    rename = require("gulp-rename"),
    sourcemaps = require('gulp-sourcemaps');

gulp.task("less-compile", function () {
    return gulp.src("./wwwroot/assets/less/site.less")
        .pipe(less())
        .pipe(gulp.dest("./wwwroot/assets/css"));
});

gulp.task("sass", function () {
    return gulp.src("./wwwroot/assets/scss/**/*.scss")
        .pipe(print())
        .pipe(sourcemaps.init())
        .pipe(sass())
        .pipe(sourcemaps.write())
        .pipe(print())
        .pipe(gulp.dest("./wwwroot/assets/scss/css"))
        .pipe(print());
})

gulp.task('sass:watch', function () {
    gulp.watch('./sass/**/*.scss', ['sass']);
});