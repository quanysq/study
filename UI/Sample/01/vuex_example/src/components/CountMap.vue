<template>
  <div>
    <h2>{{msg}}</h2>
    <hr/>
    <h3>{{ getCount }}</h3>
    <hr />
    <h2>Use mutations method by map</h2>
    <div>
      <button @click="increment">+</button>
      <button @click="decrement">-</button>
    </div>
  </div>
</template>
<script>
  import { mapGetters, mapActions } from 'vuex'

  export default {
    computed: {
      // 使用对象展开运算符将 getters 混入 computed 对象中
      ...mapGetters([
        'getCount'
        // ...
      ])
    },
    methods: {
      ...mapActions([
        'increment', // 映射 this.increment() 为 this.$store.dispatch('increment')
        'decrement'
      ])
      // ...mapActions({
      // add: 'increment' // 映射 this.add() 为 this.$store.dispatch('increment')
      // })
    }
  }
</script>
