(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-2cacc7b9"],{"99d9":function(t,e,a){"use strict";a.d(e,"c",function(){return c}),a.d(e,"a",function(){return r}),a.d(e,"b",function(){return i});var s=a("80d2"),n=a("b0af");const r=Object(s["g"])("v-card__actions"),i=Object(s["g"])("v-card__text"),c=Object(s["g"])("v-card__title");n["a"]},b0af:function(t,e,a){"use strict";a("615b");var s=a("10d2"),n=a("297c"),r=a("1c87"),i=a("58df");e["a"]=Object(i["a"])(n["a"],r["a"],s["a"]).extend({name:"v-card",props:{flat:Boolean,hover:Boolean,img:String,link:Boolean,loaderHeight:{type:[Number,String],default:4},outlined:Boolean,raised:Boolean},computed:{classes(){return{"v-card":!0,...r["a"].options.computed.classes.call(this),"v-card--flat":this.flat,"v-card--hover":this.hover,"v-card--link":this.isClickable,"v-card--loading":this.loading,"v-card--disabled":this.loading||this.disabled,"v-card--outlined":this.outlined,"v-card--raised":this.raised,...s["a"].options.computed.classes.call(this)}},styles(){const t={...s["a"].options.computed.styles.call(this)};return this.img&&(t.background=`url("${this.img}") center center / cover no-repeat`),t}},methods:{genProgress(){const t=n["a"].options.methods.genProgress.call(this);return t?this.$createElement("div",{staticClass:"v-card__progress"},[t]):null}},render(t){const{tag:e,data:a}=this.generateRouteLink();return a.style=this.styles,this.isClickable&&(a.attrs=a.attrs||{},a.attrs.tabindex=0),t(e,this.setBackgroundColor(this.color,a),[this.genProgress(),this.$slots.default])}})},b86a:function(t,e,a){"use strict";a.r(e);var s=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("v-container",{attrs:{"fill-height":""}},[a("v-layout",{attrs:{column:""}},[a("v-flex",{attrs:{shrink:""}},[a("v-card-text",[a("div",{staticClass:"text-center display-1 content-text"},[t._v("\n          "+t._s(t.$t("pages.contacts.title"))+"\n        ")])])],1),a("v-flex",[a("v-card-text",[a("p",{staticClass:"title content-text"},[t._v("\n          "+t._s(t.$t("pages.contacts.content-text"))+"\n        ")]),t._l(t.contacts,function(e,s){return a("p",{key:s},[a("v-layout",{attrs:{"align-center":"","justify-start":""}},[a("v-flex",{attrs:{shrink:"","mx-2":""}},[a("v-icon",{attrs:{color:e.color,size:"30"}},[t._v(t._s(e.icon))])],1),a("v-flex",{attrs:{shrink:"","mx-2":""}},[a("span",{staticClass:"title"},[t._v(t._s(e.title))])]),a("v-flex",{attrs:{shrink:"","mx-2":""}},[a("span",{staticClass:"subtitle-1"},[t._v(t._s(e.description))])])],1)],1)})],2)],1)],1)],1)},n=[],r=a("d225"),i=a("308d"),c=a("6bb5"),o=a("4e2b"),l=a("9ab4"),d=a("2b0e"),u=a("60a3"),v=function(t){function e(){var t;return Object(r["a"])(this,e),t=Object(i["a"])(this,Object(c["a"])(e).apply(this,arguments)),t.contacts=[{title:"E-mail:",description:"email@mail.com",icon:"fa-at",color:"red"},{title:"Telegram:",description:"@telegram",icon:"fa-telegram",color:"blue"}],t}return Object(o["a"])(e,t),e}(d["default"]);v=l["a"]([Object(u["a"])({})],v);var h=v,b=h,f=a("2877"),p=a("6544"),g=a.n(p),m=a("99d9"),_=a("a523"),x=a("0e8f"),k=a("132d"),y=a("a722"),j=Object(f["a"])(b,s,n,!1,null,null,null);e["default"]=j.exports;g()(j,{VCardText:m["b"],VContainer:_["a"],VFlex:x["a"],VIcon:k["a"],VLayout:y["a"]})}}]);
//# sourceMappingURL=chunk-2cacc7b9.910eae2d.js.map