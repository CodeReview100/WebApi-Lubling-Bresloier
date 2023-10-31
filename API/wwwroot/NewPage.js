const user = sessionStorage.getItem("user")
const jsonUser = JSON.parse(user)

const loadPage = () => {
    const jsonUser = JSON.parse(user)
    welcome.innerHTML = `hello to ${jsonUser.userName}  welcome to home page:)!!!`
    const userNameUpdate = document.getElementById("userNameUpdate")
    userNameUpdate.value = jsonUser.userName

    const passwordUpdate = document.getElementById("passwordUpdate")
    passwordUpdate.value = jsonUser.password

    const firstNameUpdate = document.getElementById("firstNameUpdate")
    firstNameUpdate.value = jsonUser.firstName

    const lastNameUpdate = document.getElementById("lastNameUpdate")
    lastNameUpdate.value = jsonUser.lastName

}

const update = async () => {
    try {
        var userId = jsonUser.userId
        var userName = document.getElementById("userNameUpdate").value
        var password = document.getElementById("passwordUpdate").value
        var firstName = document.getElementById("firstNameUpdate").value
        var lastName = document.getElementById("lastNameUpdate").value
        var User = { userId, userName, password, firstName, lastName }
        console.log(User)
        var url = 'api/users' + "/" + userId
        const res = await fetch(url, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(User)

        });
        const dataPost = await res.json();

        alert(dataPost.userName +"עודכן")
    console.log(dataPost)
    }

catch (er) {
    alert(er.message+ "ERORR")
}

}