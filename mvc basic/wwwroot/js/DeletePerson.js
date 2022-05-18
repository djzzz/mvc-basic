const deletePerson = (url, index) => {
    console.log("hej")
    $.ajax({
        method: "GET",
        url: `${url}/${index}`
    })
    .done((res) => {
        console.log(res)
        const doc = new DOMParser().parseFromString(res, "text/xml");
        const container = document.getElementById('container')
        container.innerHTML = doc.firstChild.innerHTML;
     })
}