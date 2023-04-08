document.querySelectorAll('.section').forEach(section => {
    section.addEventListener('click', () => {
      window.location.href = `/${section.id}`;
    });
  });
  