(function (window, document) {

  var layout = document.getElementById('layout');
  var menu = document.getElementById('menu');
  var menuLink = document.getElementById('menuLink');

  function toggleClass(element, className) {
    var classes = element.className.split(/\s+/);
    var length = classes.length;

    for (var i=0; i < length; i++) {
      if (classes[i] === className) {
        classes.splice(i, 1);
        break;
      }
    }
    // The className is not found
    if (length === classes.length) {
      classes.push(className);
    }

    element.className = classes.join(' ');
  }

  function toggleAll(e) {
    var active = 'active';

    e.preventDefault();
    toggleClass(layout, active);
    toggleClass(menu, active);
    toggleClass(menuLink, active);
  }

  function handleEvent(e) {
    if (e.target.id === menuLink.id) {
      return toggleAll(e);
    }

    if (menu.className.indexOf('active') !== -1) {
      return toggleAll(e);
    }
  }

  document.addEventListener('click', handleEvent);

}(this, this.document));
