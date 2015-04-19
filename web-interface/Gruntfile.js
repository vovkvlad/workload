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
            files: ['<%= jshint.files %>', '<%= appSass %>/**/*.scss'],
            tasks: ['jshint', 'clean:debug', 'concat:debug', 'sass:debug']
        },
        copy: {
            debug: {
                src: 'app/index.html',
                dest: 'build/debug/index.html'
            },
            release: {
                src: 'app/index.html',
                dest: 'build/release'
            }
        },
        concat: {
            options: {
                process: function (src, filepath) {
                    return '//####' + filepath + '\n' + src;
                }
            },
            debug: {
                src: '<%= appJs %>',
                dest: '<%= debugJs %>'
            },
            dist: {
                src: '<%= appJs %>',
                dest: '<%= releaseJs %>'
            }
        },
        sass: {
            debug: {
                options:{
                    style: 'expanded'
                },
                files: {
                    '<%= debugCss %>': '<%= appSass %>/all.scss'
                }
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
    grunt.registerTask('debug', ['jshint', 'clean:debug', 'concat:debug', 'sass:debug', 'copy:debug']);
    grunt.registerTask('release', ['jshint', 'clean:dist', 'concat:dist', 'sass:dist', 'copy:release', 'uglify']);

};