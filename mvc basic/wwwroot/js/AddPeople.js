console.log("hello")

function HandleSubmit(event) {

    const name = event.target['createPersonView.Name'].value;
    const number = event.target['createPersonView.Number'].value;
    const city = event.target['createPersonView.City'].value;
    const url = event.target['url'].value;
    console.log(name)
    $.ajax({
        method: "POST",
        url: url,
        data : {
            'createPersonView.Name' : name,
            'createPersonView.Number' : number,
            'createPersonView.City' : city
        }
    })
    .done((res) => {
        console.log(res)
        const frag = document.createRange().createContextualFragment(res);
        const container = document.getElementById('container')
        container.appendChild(frag)

     })
    event.preventDefault();
}

const form = document.getElementById('Add')
form.addEventListener('submit', HandleSubmit);