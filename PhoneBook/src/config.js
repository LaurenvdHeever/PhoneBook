module.exports = (function () {
  var URL = 'https://localhost:5001/';

  var config = {
    API: {
      getPhoneBooks: URL + 'api/phonebook',
      getPhoneBookName: URL + 'api/phonebook/',
      getContacts: URL + 'api/phonebook/contacts/',
      addContact: URL + 'api/phonebook',
    }
  }
  return config;
})();
