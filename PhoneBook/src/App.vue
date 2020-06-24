<template>
  <div id="app">
    <app-navigation></app-navigation>
    <app-phonedirectory></app-phonedirectory>
    <app-footer></app-footer>
  </div>
</template>

<script>
  import Navigation from './components/Navigation'
  import PhoneDirectory from './components/PhoneDirectory'
  import Footer from './components/Footer'

  export default {
  name: 'App',
  components: {
    'app-navigation': Navigation,
    'app-phonedirectory': PhoneDirectory,
    'app-footer': Footer
  }
}
</script>

<style lang="scss">
</style>
