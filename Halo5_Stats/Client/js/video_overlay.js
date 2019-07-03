/**
 *    Copyright 2019 Amazon.com, Inc. or its affiliates
 *
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 */

//Twitch
var twitch = window.Twitch ? window.Twitch.ext : null;


(function () {


    //vars
    var gamertag_Broadcaster = "";
    var hasFired = false;
    var jwt_Token = "";

    //Make sure in the context of twitch
    if (!twitch) {
        console.log("Twitch not found. Returning");
        return;
    }

    //Authorize
    twitch.onAuthorized(function (auth) {
        jwt_Token = auth.token;
        console.log("onAuthorized: " + auth);

        //Is this the first time in the context?
        if (hasFired == false) {
            //Get stats given a gamertag
            let myPromise = getStats(gamertag_Broadcaster, jwt_Token);
            myPromise.then(resultGetStats => {
                //Set our fields
                setStats(resultGetStats);
            })
            hasFired = true;
        }
    });

    //onChanged function
    twitch.configuration.onChanged(function () {
        gamertag_Broadcaster = twitch.configuration.broadcaster ? twitch.configuration.broadcaster.content : "";
        console.log("onChanged() fired, previously broadcaster-selected gamertag: " + gamertag_Broadcaster);
    });

})()

//Get stats data from my api
function getStats(broadcaster_gt, myJwt) {
    return new Promise((resolve, reject) => {
        $.ajax({
            'url': "https://localhost:44332/api/halo5?gamertag=" + broadcaster_gt,
            'method': "GET",
            "crossDomain": true,
            "headers": {
                'x-extension-jwt': myJwt
            }
        }).done((response) => {
                console.log("Resolving promise...");
                resolve(response);
            }).fail((error) => {
                console.log("Rejecting promise...");
                reject(error);
        });
    });
}

//populate table with stats
function setStats(statsObj) {
    var keys = Object.keys(statsObj);
    for (var i = 0; i < keys.length; i++) {
        console.log(keys[i]);
        var currentElement = document.getElementById(keys[i]);
        if (currentElement.nodeName == "IMG")
            currentElement.src = statsObj[keys[i]];
        else
            currentElement.innerHTML = statsObj[keys[i]];
    }
}

//toggle div
function toggleDiv() {
    $('#divStats').toggle();

    var showHide = document.getElementById("btn_stats").innerHTML;
    if (showHide == "Show") {
        showHide = "Hide";
    }
    else if (showHide == "Hide") {
        showHide = "Show";
    }
    document.getElementById("btn_stats").innerHTML = showHide;
}