var IdCount = 100;

const register = async () => {
    try {
        var userName = document.getElementById("userName").value
        var password = document.getElementById("password").value
        var firstName = document.getElementById("firstName").value
        var lastName = document.getElementById("lastName").value
        var User = { userName, password, firstName, lastName }

/* if()*/
        const res = await fetch('api/users', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(User)

        });

        const dataPost = await res.json();
        alert(dataPost.userName+" your regisre:)")
    }
    catch (er) {
       alert(er )
    }


}

const checkLength = () => {
    var userName = document.getElementById("userName").value
    if (userName.length > 10) {
        alert("to long")
    }
} 

var users;



const checkPasswordLevel=(password)=>{




}


const checkPassword = async () => {
    var res;
    var strength = {
        0: "Worst",
        1: "Bad",
        2: "Weak",
        3: "Good",
        4: "Strong"
    }
    var password = document.getElementById("password").value;
    var meter = document.getElementById('password-strength-meter');
    var text = document.getElementById('password-strength-text');
    await fetch('api/Users/check',
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(password)

        })
        .then(r => r.json())
        .then(data => res = data)


    if (res <= 2)
        meter.value = res;
    meter.value = res;
    if (password !== "") {
        text.innerHTML = "Strength: " + strength[res];
    } else {
        text.innerHTML = "";
    }
}




const login = async () => {
    try {
        var userNameLogin = document.getElementById("userNameLogin").value
        var passwordLogin = document.getElementById("passwordLogin").value
        var url = 'api/users' + "?" + "userName=" + userNameLogin + "&password=" + passwordLogin;
        const res = await fetch(url,);
        console.log(res)
        if (!res.ok) {
            throw new Error("eror!!!")
        }
        else {
            var data = await res.json() 
            sessionStorage.setItem("user", JSON.stringify(data))
            alert("you loged in")
            window.location.href = "./newPage.html"
   
        }
    }
    catch (er) {
        alert(er.message+"DFGHJKYYRFK")
    }
   
 
    }



