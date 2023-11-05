//I recommend to change the project name to webApiShopSite etc.

var IdCount = 100;

const register = async () => {
    try {
        //Use const
        var userName = document.getElementById("userName").value
        var password = document.getElementById("password").value
        var firstName = document.getElementById("firstName").value
        var lastName = document.getElementById("lastName").value
        var User = { userName, password, firstName, lastName }
        //const User = { UserName:userName, Password:password, FirstName:firstName, LastName:lastName }, Prefix -UpperCase 

/* if()*/
        const res = await fetch('api/users', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(User)

        });

        const dataPost = await res.json();
        //Check response status code- if response is ok..., if not alert a suitable message...
        //you register:) 
        alert(dataPost.userName+" your regisre:)")
    }
    catch (er) {
       //Alerting errors to the user is not recommended, log them to the console.
       alert(er )
    }


}

const checkLength = () => {
    //const
    var userName = document.getElementById("userName").value
    if (userName.length > 10) {
        //too
        alert("to long")
    }
} 

var users;


//Remove Unnecessary lines
const checkPasswordLevel=(password)=>{




}

//variables- const (if possible)
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
        //await! instead of .then
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
        //use `` for js strings with variables ex:userName=`${userNameLogin}`
        var url = 'api/users' + "?" + "userName=" + userNameLogin + "&password=" + passwordLogin;
        const res = await fetch(url,);
        console.log(res)
        if (!res.ok) {
            throw new Error("eror!!!")
            //Alert: userName or password incorrect try again....
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



