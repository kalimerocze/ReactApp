//import React, { useState } from 'react';
//import Axios from 'axios';

//function PostForm() {
//    const url = "https://localhost:44485/zam/Create"
//    const [data, setData] = useState({
//        jmeno:"",
//        prijmeni:"",
//        pracovniPozice : "",
//        terminVyprseniKontraktu : ""

//    })
//    const [feedback, setFeedback] = useState()

//   // const newdata ={};
//    function handle(e) {
//        const newdata = { ...data }
//        newdata[e.target.id] =e.target.value
//        setData(newdata)


//        console.log(newdata)
//    }
//    function sendFormData(e) {
//        // console.log(this.state.newdata);
//        const newdata11 = {
//            jmeno: data.jmeno,
//            prijmeni: data.prijmeni,
//            pracovniPozice: data.pracovniPozice,
//            terminVyprseniKontraktu: data.terminVyprseniKontraktu,
//        }
//        console.log(newdata11);
//        e.preventDefault();
//        //Axios.post(url,
//        //    //{
//        //    //Jmeno: data.jmeno,
//        //    //Prijmeni: data.prijmeni,
//        //    //PracovniPozice: data.pracovniPozice,
//        //    //TerminVyprseniKontraktu: data.terminVyprseniKontraktu,

//        //    //}
//        //    {data}
//        //).then(x => {
//        //    console.log(x.data)
//        //}).then(x => {
//        //    console.log(x)
//        //})
//        //var data1 = new FormData();
//        //data1.append("PoLos", JSON.stringify(newdata11));
//        ///fetch javascript fetch 
//        fetch(url, {
//            method: 'POST', // *GET, POST, PUT, DELETE, etc.
//            headers: {
//                'Content-Type': 'application/json'
//                // 'Content-Type': 'application/x-www-form-urlencoded',
//            },
//            body: JSON.stringify(newdata11) // body data type must match "Content-Type" header- musim objekt zretezit jeste
//        }).then(r=>r.json())
//            .then(feedback => setFeedback(feedback))
//            .finally(() => setData({}));
//    }

//    return (
//        <div>
//            <form onSubmit={(e)=>sendFormData(e) }>
//                <input autoComplete="off" className="input is-hovered" type="text" placeholder="Name" onChange={(e) => handle(e)} id="jmeno" value={data.jmeno} type="text"></input>
//                <input autoComplete="off" className="input is-hovered" type="text" placeholder="Surname" onChange={(e) => handle(e)} id="prijmeni" value={data.prijmeni}  type="text"></input>
//                <input autoComplete="off" className="input is-hovered" type="text" placeholder="Job position" onChange={(e) => handle(e)} id="pracovniPozice" value={data.pracovniPozice}  type="text"></input>
//                <input autoComplete="off" className="input is-hovered" type="text" placeholder="Contract expiration" onChange={(e) => handle(e)} id="terminVyprseniKontraktu" value={data.terminVyprseniKontraktu} type="text"></input>
//                <button className="button is-success" type="submit" >Odeslat</button>
//            </form>
//            {feedback && <div> { JSON.stringify(feedback)}</div>}
//        </div>
//        )
//}

//export default PostForm;