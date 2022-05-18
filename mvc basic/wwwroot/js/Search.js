function HandleSearchForm(event) {

    const search = event.target['search'].value;
    console.log(search)
    const url = event.target['url'].value;
    console.log(name)
    $.ajax({
        url: url,
        data: {
            'search': search,
        }
    })
    .done((res) => {
        
        const doc = new DOMParser().parseFromString(res, "text/xml");
        console.log(doc.firstChild)
        const container = document.getElementById('container')
        container.innerHTML = doc.firstChild.innerHTML;
        
    })
    event.preventDefault();
}

const searchForm = document.getElementById('Search')
searchForm.addEventListener('submit', HandleSearchForm);