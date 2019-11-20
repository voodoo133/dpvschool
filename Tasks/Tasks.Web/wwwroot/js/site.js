

$('.update-job').click(function (e) {
    e.preventDefault();
    e.stopImmediatePropagation();

    const jobModal = $('#job-modal');
    const id = $(this).data('id');

    fetch('/Jobs/' + id)
      .then(res => res.json())
      .then(job => {
        jobModal.find('.modal-title').text('Обновить задачу');

        jobModal.find('.job-modal__form').attr('action', '/Jobs/Update');
        jobModal.find('[name="Id"]').val(job.Id).prop('disabled', '');
        jobModal.find('[name="Name"]').val(job.Name);
        jobModal.find('[name="Description"]').val(job.Description);
        jobModal.find('[name="Tag"]').val(job.Tag);
        const date = (job.Date) ? job.Date.slice(0, job.Date.indexOf('T')) : '';
        jobModal.find('[name="Date"]').val(date);

        jobModal.find('button[type="submit"]').text('Обновить');

        jobModal.modal('show');
        console.log(job);
      })
      .catch(err => {});
      
})

$('#job-modal').on('hidden.bs.modal', function () {
  const jobModal = $(this);

  jobModal.find('.modal-title').text('Добавить задачу');

  jobModal.find('.job-modal__form').attr('action', '/Jobs/Add');
  jobModal.find('[name="Id"]').val('').prop('disabled', 'disabled');
  jobModal.find('[name="Name"]').val('');
  jobModal.find('[name="Description"]').val('');
  jobModal.find('[name="Tag"]').val('');
  jobModal.find('[name="Date"]').val('');

  jobModal.find('button[type="submit"]').text('Добавить');
});