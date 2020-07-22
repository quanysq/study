// 包装函数
module.exports = function (grunt) {

  // 任务配置，所有插件的配置信息
  grunt.initConfig({
    // 获取 package.json 的信息
    pkg: grunt.file.readJSON('package.json'),
    // uglify 插件的配置信息
    uglify: {
      options: {
        scripBanners: true,
        banner: '/*! <%= pkg.name %> <%= grunt.template.today("dd-mm-yyyy") %> */\n'
      },
      build: {
        src: 'src/test.js',
        dest: 'build/<%=pkg.name%>-<%=pkg.version%>.js.min.js'
      }
    },
    // jshint 插件的配置信息
    jshint: {
      build: ['src/*.js'],
      options: {
        jshintrc: '.jshintrc'
      }
    },
    // csslint 插件的配置信息
    csslint: {
      build: ['src/*.css'],
      options: {
        csslintrc: '.csslintrc'
      }
    },
    // watch 插件的配置信息
    watch: {
      build: {
        files: ['src/*.js', 'src/*.css'],
        tasks: ['jshint', 'uglify'],
        options: { spawn: false }
      }
    }
  });

  // 告诉 grunt 加载 uglify 插件
  grunt.loadNpmTasks('grunt-contrib-uglify');
  grunt.loadNpmTasks('grunt-contrib-jshint');
  grunt.loadNpmTasks('grunt-contrib-csslint');
  grunt.loadNpmTasks('grunt-contrib-watch');

  // 告诉 grunt 当我们在终端中输入 grunt 时需要做些什么（注意先后顺序）
  grunt.registerTask('default', ['uglify', 'jshint', 'csslint', 'watch']);
};