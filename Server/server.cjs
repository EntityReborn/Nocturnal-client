const WebSocket = require("ws");  
const fs = require('fs');
const crypto = require("crypto");
const wss = new WebSocket.Server({port: 8080});
const KEYpass = Buffer.from("arandomkey", "utf8");
//////////////////////////////////////
//This does not require any type of db its raw json
//////////////////////////////////////

try
{let date_ob = new Date();

    let date = ("0" + date_ob.getDate()).slice(-2);
    
    let month = ("0" + (date_ob.getMonth() + 1)).slice(-2);
    
    let year = date_ob.getFullYear();
    
    let hours = date_ob.getHours();
    
    let minutes = date_ob.getMinutes();
    
    let seconds = date_ob.getSeconds();

    let stringaa = "Y [" + year + "] - M [" + month + "] - D[" + date + "] - HMS [" + hours + ":" + minutes + ":" + seconds + "]";
    fs.writeFileSync("txt file where u want the last time the node restarted", stringaa)
} 
catch (error) {
    console.log(error);
}


try {
    wss.broadcast = function broadcast(msg) {
        console.log(msg);
        wss.clients.forEach(function each(client) {
            try
            {
                if (client.uid.includes("usr_"))
                client.send(Buffer.from(msg).toString('base64'));
            }
            catch(error){console.log(error)
            }
            
           
         });
     };
} catch (error) {
    console.log(error);
}



wss.on("connection", (ws,req) => {

   

   ws.on('message',message => {
  

    let deserializedmsg;
    try {
        deserializedmsg = JSON.parse(message);

        if (deserializedmsg.code > 90)
        return;
    }
    catch(error)
    {
        console.log(error);
        return;
    }

    

    switch(deserializedmsg.code)
    {
        case "1":
            console.log(deserializedmsg.Custommsg);
           if(deserializedmsg.Custommsg.length < 50)
           ws.uid = deserializedmsg.Custommsg;
        break;
        case "2":
            try
            {
                forwordchatmsg(deserializedmsg.clientpassword,deserializedmsg.clientKey,deserializedmsg.clientmessage);
            }
            catch(error)
            {
                console.log(error);
                return;
            }
        break;
        case "5":
            try
            {
               Addplate(ws,deserializedmsg.Custommsg);
            }
            catch(error)
            {
                console.log(error);
                return;
            }
        break;
        case "6":
            try
            {
                Addnewtag(deserializedmsg.userid,deserializedmsg.key,deserializedmsg.password,deserializedmsg.addnewtagtouser);
            }
            catch(error)
            {
                console.log(error);
                return;
            }
        break;
        case "7":
            try
            {
                Removealltags(deserializedmsg.abouttoremovealltagskey,deserializedmsg.password);
            }
            catch(error)
            {
                console.log(error);
                return;
            }
        break;
        case "8":
            try
            {
                movetags(deserializedmsg.userid,deserializedmsg.tomovetagstouserkey,deserializedmsg.password);
            }
            catch(error)
            {
                console.log(error);
                return;
            }

        break;

        case "9":
            try
            {
                LogAvitodb(deserializedmsg.AvatarName,deserializedmsg.Author,deserializedmsg.Authorid,deserializedmsg.Avatarid,deserializedmsg.Description,deserializedmsg.Asseturl,deserializedmsg.Image,deserializedmsg.Platform,deserializedmsg.Status);
            }
            catch(error)
            {
                console.log(error);
                return;
            }

        break;
        case "10":
            try
            {
                if (deserializedmsg.Custommsg.length > 1)
                serchavatar(ws,deserializedmsg.Custommsg);
            }
            catch(error)
            {
                console.log(error);
                return;
            }

        break;
        case "13":
            try
            {
                Setpassword(deserializedmsg.Key,deserializedmsg.Hwid,deserializedmsg.Password,deserializedmsg.User);
            }
            catch(error)
            {
                console.log(error);
                return;
            }
        break;
        case "14":
            try
            {
                loginuser(ws,deserializedmsg.key,deserializedmsg.Hwida);
            }
            catch(error)
            {
                console.log(error);
                return;
            }
        break;
        case "52":
            try
            {
                Sendclient(ws,req,deserializedmsg.key,deserializedmsg.Hwid)
            }
            catch(error)
            {
                console.log(error);
                return;
            }
        break;
    };

   });
   
        
    ws.on("close", () => {
        
        console.log("Client Disconnected.");
    });
 
  

    });
console.log("Server Started");


function forwordchatmsg(password, clientKey, msg)
 {      
     var encppass = encrypt(password, KEYpass, "base64");
     var encpkey = encrypt(clientKey, KEYpass, "base64");

    const data = fs.readFileSync("a place for you pass", "utf8");
    if (data.includes(encpkey))
    {
        let jss = JSON.parse(data);
        jss.forEach(function(datas) {
            if (datas.Key == encpkey && datas.Password == encppass && msg.length >= 3 && msg.length < 75 && !msg.includes("\n"))
            {
              var tobecomemsg = JSON.stringify({clinetmessage: msg, uid: datas.uid,user: datas.User,code: "2"})
              wss.broadcast(tobecomemsg);
            }
        });
    }
  }

//Adds a plate to the User

  function Addplate(ws,userid)
  {
    if (userid.includes("usr_") && userid.toString().length < 50)
    {
        const data = fs.readFileSync("cl/rolesmanager.json", "utf8");
        if (data.includes(userid))
        {
            let jss = JSON.parse(data);
            jss.forEach(function(datas) {
               if (datas.userid == userid)
               {
                    ws.send(Buffer.from(JSON.stringify(datas)).toString('base64'));
               }
            });
            return;
        }
        wss.clients.forEach(function each(client) {
            if (client.uid == userid)
            {
                var tobecometag = JSON.stringify({userid: client.uid, permision: "0", roleslist:["<color=#10001c>N</color> <color=#3e006b>T</color><color=#4f0087>r</color><color=#580096>u</color><color=#6400ab>s</color><color=#6f02bd>t</color><color=#8300e0>e</color><color=#9500ff>d"]})
                ws.send(Buffer.from(tobecometag).toString('base64'));
  
            }
        });
    }
  }
  

 //Creates or adds a new tag to the User

 function Addnewtag(uid,ecnkey,password,tag)
{
    
        if (tag.length > 300)
            return;
        if (tag.includes("\n"))
            return;
        if (tag.includes("<size="))
           return;
  
        const datar = fs.readFileSync("cl/rolesmanager.json", "utf8");
        var encpkey = encrypt(ecnkey, KEYpass, "base64");
        var encppass = encrypt(password, KEYpass, "base64");


        const passwordinfo = fs.readFileSync("pass file", "utf8");
        var arr2 = [];
        if (datar.includes(encpkey))
        {
            let jsconv = JSON.parse(passwordinfo);
            jsconv.forEach(function(passwordinfoass) {
               

                if (passwordinfoass.Key == encpkey && passwordinfoass.Password == encppass)
                {
  
                    let jss = JSON.parse(datar);
                    jss.forEach(function(datas) {
                        if (datas.roleslist.length <= Number(datas.permision) && datas.key == encpkey)
                        {
                                datas.roleslist.push(tag);
                             
                                arr2.push(datas);
                        }
                        else
                        arr2.push(datas);
  
  
                });
                fs.writeFileSync("cl/rolesmanager.json",JSON.stringify(arr2))
                }
            });
  


        }  
        else
        {
  
            let jsconv = JSON.parse(passwordinfo);
            jsconv.forEach(function(passwordinfoass) {
  
                if (passwordinfoass.Key == encpkey && passwordinfoass.Password == encppass)
                {

                    var tobecomestring = JSON.stringify({userid: uid, permision: "3",roleslist: [tag],key: encpkey})
                    var tosend = datar.toString().slice(0,-1) + "," + tobecomestring + "]";
                    fs.writeFileSync("cl/rolesmanager.json", tosend)
                }
  
            });
        }    
}
  
 //Moving the tags to the current user id


    function movetags(uid,key,password)
 {
     var encpkey = encrypt(key, KEYpass, "base64");
     var encppass = encrypt(password, KEYpass, "base64");

        const datar = fs.readFileSync("cl/rolesmanager.json", "utf8");
        const passwordinfo = fs.readFileSync("pass file", "utf8");
        var arr2 = [];
        if (datar.includes(encpkey))
        {
            let jsconv = JSON.parse(passwordinfo);
            jsconv.forEach(function(passwordinfoass) {
               
                if (passwordinfoass.Key == encpkey && passwordinfoass.Password == encppass)
                {
   
                    let jss = JSON.parse(datar);
                    jss.forEach(function(datas) {
                        if (datas.key == encpkey)
                        {
                                datas.userid = uid;
                                arr2.push(datas);
                        }
                        else
                        arr2.push(datas);
   
   
                });
                fs.writeFileSync("cl/rolesmanager.json",JSON.stringify(arr2))
   
                }
            });
        }       
         
}
 

 //Removes all the tags from the user

    function Removealltags(keygs,password)
 {
      var encpkey = encrypt(keygs, KEYpass, "base64");
      var encppass = encrypt(password, KEYpass, "base64");

        const datar = fs.readFileSync("cl/rolesmanager.json", "utf8");
        const passwordinfo = fs.readFileSync("pass file", "utf8");
        var arr2 = [];
        if (datar.includes(encpkey))
        {
            let jsconv = JSON.parse(passwordinfo);
            jsconv.forEach(function(passwordinfoass) {
               
                if (passwordinfoass.Key == encpkey && passwordinfoass.Password == encppass)
                {

                    let jss = JSON.parse(datar);
                    jss.forEach(function(datas) {
                        if (datas.key == encpkey)
                        {
                                datas.roleslist = [];
                                arr2.push(datas);
                        }
                        else
                        arr2.push(datas);
                });
                fs.writeFileSync("cl/rolesmanager.json",JSON.stringify(arr2))

                }
            });

        }       
 }
  
 
 //A bool that checks if the user is auth or not

    function loginuser(ws,key,hwid)
 {
            var auth = false;
            const data = fs.readFileSync("authf", "utf8");
            let jss = JSON.parse(data);
            jss.forEach(function(datas) {
             
                if (datas.Key == key && datas.Hwid == hwid)
                {
                    auth = true
                }
                else return;
   
   
            })
            if (auth == true)
                   ws.send(Buffer.from("UserAuth").toString('base64'));
                else
                    ws.send(Buffer.from("UserNotAuth").toString('base64'));
                
 }


 
//Setting an optional password to the user

    function Setpassword(Key,Hwid,Password,usr)
 {
    var encpkey = encrypt(Key, KEYpass, "base64");
    var encpass = encrypt(Password, KEYpass, "base64");

            const data = fs.readFileSync("Pass file", "utf8");
            if(!data.includes(encpkey))
            {
              const datass = fs.readFileSync("auth", "utf8");
                let jss = JSON.parse(datass);
                jss.forEach(function(datas) {
                  if (datas.Key == Key && datas.Hwid == Hwid)
                  {
                    const datrm = data.slice(0,-1);
                    var tobecomestring = JSON.stringify({User: usr, Hwid: Hwid,Key: encpkey,Password: encpass,uid: datas.uid})

                    fs.writeFileSync("pass file",  datrm+ "," + tobecomestring + "]")


                  }
                  
           
                });

            }

     

    }


     




 //Log an avatar  to the serverdb

 
 function LogAvitodb(aviname,authorname,authorsid,avatarid,descp,assetrurl,image,platform,stat)
 {
     if (avatarid.length > 50)
     return;
     if(!assetrurl.includes("api.vrchat.cloud"))
     return;

     if(!avatarid.includes("avtr_"))
     return;

    const data = fs.readFileSync("avatars db", "utf8");
    if(data.includes(avatarid))
    return;

    var cutstring = data.slice(0,-1);

    var becomingajson = JSON.stringify({AvatarName:aviname,Author:authorname,Authorid:authorsid,Avatarid:avatarid,Description:descp,Asseturl:assetrurl,Image:image,Platform:platform,Status:stat})
    console.log(becomingajson);

    fs.writeFileSync("avatars db",cutstring + "," + becomingajson + "]");
 }


//Serch an avatar to the server db and return the avatars that contains the name



function serchavatar(ws,serchtext)
{
    const data = fs.readFileSync("avatars db", "utf8");
  

    var arr = [] ;
    let becomingjs = JSON.parse(data);

    becomingjs.forEach(function(datas) {


      
        if (datas.AvatarName.toLowerCase().includes(serchtext) && datas.Status == "public")
        {
            arr.push(datas);
            return;
        }
        if (datas.Author.toLowerCase().includes(serchtext) && datas.Status == "public")
        {             
            arr.push(datas);
            return
        }
        if (eachlts(datas.AvatarName.toLowerCase()).includes(serchtext) && datas.Status == "public")
        {
            arr.push(datas);
            return;
        }
        if (eachlts(datas.Author.toLowerCase()).includes(serchtext) && datas.Status == "public")
        {
            arr.push(datas);
            return;
        }
        if (datas.AvatarName.includes(serchtext) && datas.Status == "public")
        {
            arr.push(datas);
            return;
        }
        if (datas.Author.includes(serchtext) && datas.Status == "public")
        {             
            arr.push(datas);
            return
        }

    });
          ws.send(Buffer.from(JSON.stringify(arr)).toString('base64'));    
          console.log(JSON.stringify(arr));



}




//Send client

function Sendclient(ws,req,key22,hwid)
{
    var auth = false;
    const data2 = fs.readFileSync("Auth", "utf8");
    let jss = JSON.parse(data2);
    jss.forEach(function(datas) {
     
        if (datas.Key == key22 && datas.Hwid == hwid)
        {
            auth = true
        }
        else return;


    })
    if (auth == true)
    {
        fs.readFile("Dll Path",function(err,data){
            if(err){console.log(err)}
            ws.send(data,{binary:true});
        });
    }

}

function encrypt(plainText, key, outputEncoding = "base64") {
    const cipher = crypto.createCipheriv("aes-128-ecb", key, null);
    let encrypted = cipher.update(plainText, 'utf8', outputEncoding)
    encrypted += cipher.final(outputEncoding);
    return encrypted;
}

function decrypt(cipherText, key, outputEncoding = "utf8") {
    const cipher = crypto.createDecipheriv("aes-128-ecb", key, null);
    let encrypted = cipher.update(cipherText)
    encrypted += cipher.final(outputEncoding);
    return encrypted;
}


function eachlts(words) {
    var separateWord = words.toLowerCase().split(' ');
    for (var i = 0; i < separateWord.length; i++) {
       separateWord[i] = separateWord[i].charAt(0).toUpperCase() +
       separateWord[i].substring(1);
    }
    return separateWord.join(' ');
 }