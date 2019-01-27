Vue.component('modal', {
    template: '#modal-template',
})

Vue.component('wide-modal', {
    template: '#modal-template-wide',
})

var newLoanVm = new Vue({
  el: '#new-loan-btn',
  data: {
    showModal: false,
    id: '',
    borrowerName:'',
    repaymentAmount:'',
    fundingAmount:'',
  },
    methods: {
        process: function() {
            axios.post('https://localhost:5001/api/loan', {
                id: this.id,
                borrowerName: this.borrowerName,
                repaymentAmount: this.repaymentAmount,
                fundingAmount: this.fundingAmount,
                headers: {
                    'content-type': 'application/json'
                    }
                })
                .then(response => {
                    alert('New loan with ID: ' + this.id + ' was created successfully.')
                }).catch(error => {
                    console.log(error);
                })
        }
    }
})

new Vue({
  el: '#view-id-btn',
  data: {
    showModal: false,
    id: ''
    },
    methods: {
        process: function() {
        axios.get('https://localhost:5001/api/loan')
        .then(response => {
            this.result = response.data;
            var numLoans = this.result.length;
            var requestedLoan;
            var found = false;
            for (var i = 0; i < numLoans; i++) {
                if (this.result[i].id == this.id) {
                    requestedLoan = this.result[i];
                    found = true
                    break;}
            }
            if (found !== true) {
                alert('Loan with ID: ' + this.id + ' could not be found.');
            }
            alert('Loan with ID: ' + requestedLoan.id + ' is associated with ' + requestedLoan.borrowerName + ', whose funding amount is £' + requestedLoan.fundingAmount + ' and repayment amount is £' + requestedLoan.repaymentAmount + '.');
        }).catch(error => {
            console.log(error);
        })
    }
  }
})

new Vue({
  el: '#view-all-btn',
  data: function() {
    return{
    showModal: false,
    tableData: []
    }
  },
  methods: {
    process: function() {
        axios.get('https://localhost:5001/api/loan')
        .then(response => {
            this.tableData = response.data;
        }).catch(error => {
            console.log(error);
        })
    },
  },
})

new Vue({
  el: '#delete-id-btn',
  data: {
    showModal: false,
    id: '',
  },
  methods: {
    process: function() {
        axios.delete('https://localhost:5001/api/loan/' + this.id)
        .then(response => {
            alert('Loan with ID: ' + this.id + ' was successfully deleted.')
        }).catch(error => {
            console.log(error);
        })
    }
  }
})
