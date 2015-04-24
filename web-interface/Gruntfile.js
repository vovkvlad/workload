module.exports = function(grunt) {

    grunt.initConfig({
        jshint: {
            files: ['Gruntfile.js', '<%= appJs %>'],
            options: {
                globals: {
                    jQuery: true
                }
            }
        },
        watch: {
            files: ['<%= jshint.files %>', '<%= appSass %>/**/*.scss', 'app/index.html'],
            tasks: ['clean:debug', 'concat:debug', 'copy:debug', 'sass:debug']
        },
        copy: {
            debug: {
                files: [
                    {expand: true, cwd: 'app/vendor/materialize-src/', src: ['font/**'], dest: '<%= debugDir %>/vendor'},
                    {expand: true, cwd: 'app', src: 'index.html', dest: 'build/debug/'}
                ]
            },
            release: {
                src: 'app/index.html',
                dest: 'build/release'
            }
        },
        concat: {
            options: {
                process: function (src, filepath) {
                    return '//####' + filepath + '\n' + src +'\n';
                }
            },
            debug: {
                files: [
                    {src: ['app/scripts/**/*.module.js','app/scripts/**/*.module.config.js','<%= appJs %>'], dest: '<%= debugJs %>'}
                ]
            },
            dist: {
                files: [
                    {src: ['app/scripts/**/*.module.js', 'app/scripts/**/*.module.config.js', '<%= appJs %>'], dest: '<%= releaseJs %>'}
                ]
            }
        },
        sass: {
            debug: {
                options:{
                    style: 'expanded'
                },
                files: [
                    {src: '<%= appSass %>/all.scss', dest: '<%= debugCss %>'},
                    {src: 'app/vendor/materialize-src/sass/materialize.scss', dest:'<%= debugDir %>/vendor/css/materialize.css'}
                ]
            },
            dist: {
                options: {
                    style: 'compressed'
                },
                files: {
                    '<%= releaseCss %>': '<%= appSass %>/all.scss'
                }
            }
        },
        uglify: {
            dist: {
                files: {
                    '<%= releaseMinJs %>': ['<%= releaseJs %>'],
                    '<%= releaseMinCss %>': ['<%= releaseCss %>']
                }
            }
        },
        clean: {
            debug: ["<%= debugDir %>"],
            release: ["<%= releaseDir %>"]
        },
        // GRUNT VARIABLES
        appJs: 'app/scripts/**/*.js',
        appSass: 'app/sass',

        debugDir: 'build/debug',
        debugJs: '<%= debugDir %>/app.js',
        debugCss: '<%= debugDir %>/app.css',

        releaseDir: 'build/release',
        releaseJs: '<%= releaseDir %>/app.js',
        releaseCss: '<%= releaseDir %>/app.css',
        releaseMinJs: '<%= releaseDir %>/app.min.js',
        releaseMinCss: '<%= releaseDir %>/app.min.css'
    });

    grunt.loadNpmTasks('grunt-contrib-jshint');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-sass');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-clean');
    grunt.loadNpmTasks('grunt-contrib-copy');

    grunt.registerTask('default', ['jshint']);
    grunt.registerTask('debug', ['jshint', 'clean:debug', 'concat:debug','copy:debug', 'sass:debug', 'watch']);
    grunt.registerTask('release', ['jshint', 'clean:dist', 'concat:dist', 'copy:debug', 'sass:dist', 'uglify']);

};