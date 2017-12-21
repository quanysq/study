import Vue from 'vue'
import Router from 'vue-router'
import Count from '@/components/Count'
import CountMap from '@/components/CountMap'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'index',
      component: Count
    },
    {
      path: '/countmap',
      name: 'countmap',
      component: CountMap
    }
  ]
})
