<template>
  <nav class="navbar navbar-light navbar-expand-md custom-header">
    <div class="container-fluid">
      <div><a class="navbar-brand text-light" style="font-family: Montserrat, sans-serif;">ABSA ASSESSMENT</a></div>
      <ul class="nav navbar-nav ml-auto" style="color: rgb(213,218,224);">
        <li class="nav-item" role="presentation"><a class="nav-link text-light" href="#" style="color: rgb(255,255,255);font-family: Montserrat, sans-serif;">PHONE BOOK APPLICATION</a></li>
      </ul>
    </div>
  </nav>
</template>

<script>
    export default {
        name: "navigation",
      data () {
        return {
        }
      }
    }
</script>
<style>
  .custom-header {
    background: #292c2f;
    padding: 20px 40px;
    box-sizing: border-box;
    border: 0;
    border-radius: 0;
  }

  .custom-header a.navbar-brand {
    color: #fff;
    font: normal 28px Cookie, Arial, Helvetica, sans-serif;
    line-height: 0.5;
    margin-right: 40px;
    background: #292c2f;
  }

  .custom-header a.navbar-brand span {
    color: #bc40df;
  }

  .custom-header ul.nav.navbar-nav.links li a {
    font: 14px Arial, Helvetica, sans-serif;
    opacity: 0.9;
    text-decoration: none;
    color: #fff;
    background: #292c2f;
    border: 0;
  }

  .custom-header ul.nav.navbar-nav li a:hover {
    opacity: 1;
  }

  .custom-header .badge {
    position: absolute;
    top: 4px;
    border-radius: 2px;
    font-size: 11px;
    color: #fff;
    background-color: #2A6A92;
    padding: 4px 4px;
    font-weight: normal;
  }

  .custom-header li.dropdown .dropdown-toggle {
    border-radius: 2px;
    color: #fff;
    padding: 12px 14px;
    background: #3a3c3e;
    opacity: 0.9;
    border: 0;
    margin: 0;
  }

  .custom-header li.dropdown .dropdown-toggle:focus, .custom-header li.dropdown .dropdown-toggle:hover, .custom-header li.dropdown .dropdown-toggle:active {
    background: #3a3c3e;
    color: #fff;
  }

  .custom-header ul.nav.navbar-nav.navbar-right .dropdown li a {
    font: bold 13px Arial, Helvetica, sans-serif;
  }

  .custom-header .dropdown ul {
    background-color: #3a3c3e;
    border: 0;
    min-width: 140px;
  }

  .custom-header .dropdown ul li {
    background-color: #3a3c3e;
    padding: 7px;
    text-align: center;
  }

  .custom-header .dropdown ul li a {
    background: #3a3c3e;
    border-radius: 2px;
    color: #fff;
    padding: 0;
  }

  .custom-header .dropdown ul li a:active, .custom-header .dropdown ul li a:focus, .custom-header .dropdown ul li a:hover {
    background: #3a3c3e;
  }

  .custom-header .dropdown ul li.active a {
    color: #e9ac09 !important;
  }


</style>
