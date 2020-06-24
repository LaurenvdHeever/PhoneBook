<template>
  <body id="page-top">
  <header class="masthead bg-primary text-white text-center">
    <div class="container" style="padding: 0px, 0px, 0px, 0px;">
      <div class="row">
        <div class="col offset-lg-3 text-left">

          <div class="row" style="padding: 10px;">
            <div class="col">
              <div class="text-left x-drop-btn" style="font-family: Montserrat, sans-serif;width: 500px;">
                <span>{{phoneBookName}}</span></div>
            </div>
          </div>

          <div class="row" style="padding: 10px;">
            <div class="col">
              <div style="width: 500px;">
                <div class="text-left x-drop-btn" style="font-family: Montserrat, sans-serif;">
                  <form><input @input="search" v-model="search" class="form-control" type="search" placeholder=" Search" style="padding: 0px 0px; border: 0;"></form>
                </div>
              </div>
            </div>
          </div>

          <div class="row" style="padding: 10px;">
            <div class="col">
              <div class="text-left x-drop-btn" style="font-family: Lato, sans-serif;padding: 20px;margin: 0px;width: 500px;height: 250px; overflow-y: scroll">
                <ul class="list-unstyled" v-for="contact in filteredContactList" :key="contact.PhoneNumberId">
                  <li>{{ contact.name}} {{ contact.phoneNumber}} </li>
                </ul>
              </div>
            </div>
          </div>

          <div class="row" style="padding: 10px;">
            <div class="col-lg-3" style="margin: 0px;">
              <div class="x-dropdown dropdown">
                <div class="text-left x-drop-btn" data-toggle="dropdown" aria-expanded="false" style="font-family: Montserrat, sans-serif;">
                  <form><input class="form-control" v-model="addName" type="search" placeholder=" Name" style="padding: 0px 0px; border: 0;"></form>
                </div>
              </div>
            </div>
            <div class="col-lg-3">
              <div class="x-dropdown dropdown">
                <div class="text-left x-drop-btn" data-toggle="dropdown" aria-expanded="false" style="font-family: Montserrat, sans-serif;">
                  <form><input class="form-control" v-model="addNumber" type="search" placeholder=" Number" style="padding: 0px 0px; border: 0;"></form>
                </div>
              </div>
            </div>
            <div class="col-lg-2">
              <i class="fa fa-plus" style="font-size: 55px;"  @click="addContact()"></i>
            </div>
          </div>

        </div>
      </div>
    </div>
  </header>
  </body>
</template>

<script>

  import axios from 'axios'

  var config = require('../config.js')

    export default {
      data () {
        return {
          phoneBookName: '',
          contacts: [],
          search: '',
          addName: '',
          addNumber: ''
        }
      },
      created () {
        this.getPhoneBookName(config.API.getPhoneBookName);
        this.getContactcs();
      },
      methods:
        {
          getPhoneBookName(section)
          {
            axios({
              method: 'get',
              url: config.API.getPhoneBookName + 1,
              headers: {},
            }).then((response) => {
              this.phoneBookName = response.data;
            }).catch( error => {console.log(error); });
          },
          getContactcs()
          {
            axios({
              method: 'get',
              url: config.API.getContacts + 1,
              headers: {},
            }).then((response) => {
              this.contacts = response.data;

            }).catch( error => {console.log(error); });
          },
          addContact()
          {
            axios({
              method: 'put',
              url: config.API.addContact,
              headers: {},
              data: {
                phoneBookId: 1,
                name: this.addName,
                phoneNumber: this.addNumber
              }
            }).then((response) => {
              this.contacts.unshift( {phoneBookId: 1, name: this.addName, phoneNumber: this.addNumber});
              console.log(response);


          }).catch( error => {console.log(error); });;
          },
        },
      computed: {
        filteredContactList() {
          return this.contacts.filter((entry) => entry.name.toLowerCase().match(this.search.toLowerCase()) ||
            entry.phoneNumber.match(this.search));
        }
      }
    }

</script>

<style scoped>

  .x-drop-btn {
    width: 100%;
    border-radius: 30px;
    background-color: white;
    box-shadow: 0px 1px 2px 0px rgba(0,0,0,0.05);
    padding: 9px 1.25rem;
    color: #666;
    font-size: 1.25rem;
    font-weight: 500;
  }

  @media (min-width:992px) {
    header.masthead {
      padding-top: calc(6rem + 106px);
      padding-bottom: 6rem;
    }
  }

  header.masthead {
    padding-top: calc(6rem + 40px);
    padding-bottom: 6rem;
  }

  .bg-primary {
    background-color: #18bc9c!important;
  }

  .text-white {
    color: #fff!important;
  }

  @media (min-width:992px) {
    .offset-lg-3 {
      margin-left: 25%;
    }
  }

  .col {
    -ms-flex-preferred-size: 0;
    flex-basis: 0;
    -ms-flex-positive: 1;
    flex-grow: 1;
    min-width: 0;
    max-width: 100%;
  }

  .col, .col-1, .col-2, .col-3, .col-4, .col-5, .col-6, .col-7, .col-8, .col-9, .col-10, .col-11, .col-12, .col-auto, .col-lg, .col-lg-1, .col-lg-2, .col-lg-3, .col-lg-4, .col-lg-5, .col-lg-6, .col-lg-7, .col-lg-8, .col-lg-9, .col-lg-10, .col-lg-11, .col-lg-12, .col-lg-auto, .col-md, .col-md-1, .col-md-2, .col-md-3, .col-md-4, .col-md-5, .col-md-6, .col-md-7, .col-md-8, .col-md-9, .col-md-10, .col-md-11, .col-md-12, .col-md-auto, .col-sm, .col-sm-1, .col-sm-2, .col-sm-3, .col-sm-4, .col-sm-5, .col-sm-6, .col-sm-7, .col-sm-8, .col-sm-9, .col-sm-10, .col-sm-11, .col-sm-12, .col-sm-auto, .col-xl, .col-xl-1, .col-xl-2, .col-xl-3, .col-xl-4, .col-xl-5, .col-xl-6, .col-xl-7, .col-xl-8, .col-xl-9, .col-xl-10, .col-xl-11, .col-xl-12, .col-xl-auto {
    position: relative;
    width: 100%;
    padding-right: 15px;
    padding-left: 15px;
  }

  .row {
    display: -ms-flexbox;
    display: flex;
    -ms-flex-wrap: wrap;
    flex-wrap: wrap;
    margin-right: -15px;
    margin-left: -15px;
  }

  a {
    color: #8e888a;
    text-decoration: none;
    outline: none;
  }

  a:hover, a:focus {
    color: #a7a0a2;
  }

  @media (max-width:767px) {
    a {
      font-size: 25px;
    }
  }

  .x-drop-btn {
    width: 100%;
    border-radius: 30px;
    background-color: white;
    box-shadow: 0px 1px 2px 0px rgba(0,0,0,0.05);
    padding: 9px 1.25rem;
    color: #666;
    font-size: 1.25rem;
    font-weight: 500;
  }

  .x-drop-btn:hover {
    cursor: pointer;
  }

  .x-drop-btn i {
    position: absolute;
    font-size: 32px;
    right: 16px;
  }

</style>
