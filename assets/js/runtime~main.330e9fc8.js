(()=>{"use strict";var e,a,d,f,t,r={},b={};function c(e){var a=b[e];if(void 0!==a)return a.exports;var d=b[e]={exports:{}};return r[e].call(d.exports,d,d.exports,c),d.exports}c.m=r,e=[],c.O=(a,d,f,t)=>{if(!d){var r=1/0;for(i=0;i<e.length;i++){d=e[i][0],f=e[i][1],t=e[i][2];for(var b=!0,o=0;o<d.length;o++)(!1&t||r>=t)&&Object.keys(c.O).every((e=>c.O[e](d[o])))?d.splice(o--,1):(b=!1,t<r&&(r=t));if(b){e.splice(i--,1);var n=f();void 0!==n&&(a=n)}}return a}t=t||0;for(var i=e.length;i>0&&e[i-1][2]>t;i--)e[i]=e[i-1];e[i]=[d,f,t]},c.n=e=>{var a=e&&e.__esModule?()=>e.default:()=>e;return c.d(a,{a:a}),a},d=Object.getPrototypeOf?e=>Object.getPrototypeOf(e):e=>e.__proto__,c.t=function(e,f){if(1&f&&(e=this(e)),8&f)return e;if("object"==typeof e&&e){if(4&f&&e.__esModule)return e;if(16&f&&"function"==typeof e.then)return e}var t=Object.create(null);c.r(t);var r={};a=a||[null,d({}),d([]),d(d)];for(var b=2&f&&e;"object"==typeof b&&!~a.indexOf(b);b=d(b))Object.getOwnPropertyNames(b).forEach((a=>r[a]=()=>e[a]));return r.default=()=>e,c.d(t,r),t},c.d=(e,a)=>{for(var d in a)c.o(a,d)&&!c.o(e,d)&&Object.defineProperty(e,d,{enumerable:!0,get:a[d]})},c.f={},c.e=e=>Promise.all(Object.keys(c.f).reduce(((a,d)=>(c.f[d](e,a),a)),[])),c.u=e=>"assets/js/"+({68:"10f76bbd",72:"52804278",1244:"d85a39be",1256:"902b04f6",1420:"6373637a",1496:"fbd836ef",1510:"031dc046",1650:"25bfd71f",1652:"9ed00105",1728:"755cfc2e",1956:"18116e9d",2032:"e02badcb",2256:"92bb876c",2632:"c4f5d8e4",2640:"3c5916b7",2696:"a09c2993",2804:"1f220079",2820:"dd053733",3456:"0951e901",3744:"27d9d47d",4232:"516486bd",4304:"5e95c892",4364:"9008bace",4412:"e8057f2a",4416:"b38eaed3",4666:"a94703ab",4904:"700347c0",5068:"3abe8fb9",5104:"e3c15a47",5288:"22a09cbf",5604:"e06aacec",5696:"935f2afb",5756:"f380f515",5792:"a1189d06",5828:"8581bb41",5848:"bbb8f1f8",6064:"15560a88",6132:"1aaf601c",6368:"293befc8",6385:"73139ff1",6500:"a7bd4aaa",6752:"17896441",6824:"16b2da92",7012:"39268648",7536:"35214713",7940:"266dfd57",7944:"d0e245df",8192:"8ddd655f",8224:"e6afeee9",8296:"e27d08ab",8740:"67d5074e",8804:"2851a227",9448:"b5ab5f4e",9700:"cd5a7ece"}[e]||e)+"."+{68:"6c943902",72:"7cff6343",1244:"7ff44bbd",1256:"d80e192a",1420:"8e27fef8",1496:"ee5aee49",1510:"561c7f26",1650:"2fb10f52",1652:"aab6e6a0",1728:"3cfbd4ae",1956:"b2c4e59b",2032:"327e0182",2256:"74532f51",2632:"59945ab7",2640:"8026b8f6",2696:"03fb3416",2804:"74b9fffe",2820:"962921d5",3456:"3ca2f94b",3744:"0875a247",4232:"43b6a45a",4304:"29d10178",4364:"08c77926",4412:"23db23a5",4416:"64ffcb8f",4666:"d9369941",4904:"3bbf5678",5068:"09065dee",5104:"fa544c98",5288:"f7a97e85",5604:"2945d926",5648:"5b93880e",5696:"d6dd8b33",5756:"8fe939f9",5792:"d164ed8d",5828:"a5d02b65",5848:"53ce67db",6032:"b263d1e6",6064:"0f010dfa",6132:"46855c8a",6368:"e503ee8c",6385:"6ef9b44f",6500:"6102363b",6752:"4776e2bb",6824:"b066dd25",7012:"80fa4377",7536:"942a5492",7940:"5e9f1bc1",7944:"43b7d54a",8192:"a51c079e",8224:"31c7ed22",8296:"e450b694",8740:"19498606",8804:"0a05fcba",9448:"aa6fccf8",9700:"d67b82fe"}[e]+".js",c.miniCssF=e=>{},c.g=function(){if("object"==typeof globalThis)return globalThis;try{return this||new Function("return this")()}catch(e){if("object"==typeof window)return window}}(),c.o=(e,a)=>Object.prototype.hasOwnProperty.call(e,a),f={},t="spotify-api-docs:",c.l=(e,a,d,r)=>{if(f[e])f[e].push(a);else{var b,o;if(void 0!==d)for(var n=document.getElementsByTagName("script"),i=0;i<n.length;i++){var u=n[i];if(u.getAttribute("src")==e||u.getAttribute("data-webpack")==t+d){b=u;break}}b||(o=!0,(b=document.createElement("script")).charset="utf-8",b.timeout=120,c.nc&&b.setAttribute("nonce",c.nc),b.setAttribute("data-webpack",t+d),b.src=e),f[e]=[a];var l=(a,d)=>{b.onerror=b.onload=null,clearTimeout(s);var t=f[e];if(delete f[e],b.parentNode&&b.parentNode.removeChild(b),t&&t.forEach((e=>e(d))),a)return a(d)},s=setTimeout(l.bind(null,void 0,{type:"timeout",target:b}),12e4);b.onerror=l.bind(null,b.onerror),b.onload=l.bind(null,b.onload),o&&document.head.appendChild(b)}},c.r=e=>{"undefined"!=typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})},c.p="/SpotifyAPI-NET/",c.gca=function(e){return e={17896441:"6752",35214713:"7536",39268648:"7012",52804278:"72","10f76bbd":"68",d85a39be:"1244","902b04f6":"1256","6373637a":"1420",fbd836ef:"1496","031dc046":"1510","25bfd71f":"1650","9ed00105":"1652","755cfc2e":"1728","18116e9d":"1956",e02badcb:"2032","92bb876c":"2256",c4f5d8e4:"2632","3c5916b7":"2640",a09c2993:"2696","1f220079":"2804",dd053733:"2820","0951e901":"3456","27d9d47d":"3744","516486bd":"4232","5e95c892":"4304","9008bace":"4364",e8057f2a:"4412",b38eaed3:"4416",a94703ab:"4666","700347c0":"4904","3abe8fb9":"5068",e3c15a47:"5104","22a09cbf":"5288",e06aacec:"5604","935f2afb":"5696",f380f515:"5756",a1189d06:"5792","8581bb41":"5828",bbb8f1f8:"5848","15560a88":"6064","1aaf601c":"6132","293befc8":"6368","73139ff1":"6385",a7bd4aaa:"6500","16b2da92":"6824","266dfd57":"7940",d0e245df:"7944","8ddd655f":"8192",e6afeee9:"8224",e27d08ab:"8296","67d5074e":"8740","2851a227":"8804",b5ab5f4e:"9448",cd5a7ece:"9700"}[e]||e,c.p+c.u(e)},(()=>{var e={296:0,2176:0};c.f.j=(a,d)=>{var f=c.o(e,a)?e[a]:void 0;if(0!==f)if(f)d.push(f[2]);else if(/^2(17|9)6$/.test(a))e[a]=0;else{var t=new Promise(((d,t)=>f=e[a]=[d,t]));d.push(f[2]=t);var r=c.p+c.u(a),b=new Error;c.l(r,(d=>{if(c.o(e,a)&&(0!==(f=e[a])&&(e[a]=void 0),f)){var t=d&&("load"===d.type?"missing":d.type),r=d&&d.target&&d.target.src;b.message="Loading chunk "+a+" failed.\n("+t+": "+r+")",b.name="ChunkLoadError",b.type=t,b.request=r,f[1](b)}}),"chunk-"+a,a)}},c.O.j=a=>0===e[a];var a=(a,d)=>{var f,t,r=d[0],b=d[1],o=d[2],n=0;if(r.some((a=>0!==e[a]))){for(f in b)c.o(b,f)&&(c.m[f]=b[f]);if(o)var i=o(c)}for(a&&a(d);n<r.length;n++)t=r[n],c.o(e,t)&&e[t]&&e[t][0](),e[t]=0;return c.O(i)},d=self.webpackChunkspotify_api_docs=self.webpackChunkspotify_api_docs||[];d.forEach(a.bind(null,0)),d.push=a.bind(null,d.push.bind(d))})()})();