<template>
    <div>
      <myHeader></myHeader>
      <a href="/home">go back</a>
      <h2 v-text="dat.title"></h2>
      <p>
        <b>Author:</b> {{ dat.author.loginname }}    <b>Publish at:</b> {{ $utils.goodTime(dat.create_at) }}
      </p>
      <article v-html="dat.content"></article>
      <h3>Reply:</h3>
      <ul>
        <li v-for="i in dat.replies">
          <p>
            <b>Reviewer:</b> {{ i.author.loginname }} <b>Replied at:</b> {{ $utils.goodTime(i.create_at) }}
          </p>
          <article v-html="i.content"></article>
        </li>
      </ul>
      <myFooter></myFooter>
    </div>
</template>

<script>
import myHeader from '../components/header.vue'
import myFooter from '../components/footer.vue'

export default {
  components: {
    myHeader, myFooter
  },
  data () {
    return {
      id: this.$route.params.id,
      dat: {}
    }
  },
  created () {
    console.log(this.$route)
    this.getData()
  },
  methods: {
    getData () {
      this.$api.get('topic/' + this.id, null, r => {
        console.log(r.data)
        this.dat = r.data
      })
    }
  }
}
</script>

