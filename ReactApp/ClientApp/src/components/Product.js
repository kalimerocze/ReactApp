import React, { useState } from 'react';


function Product({ productName,price , onClickHandler}) {
    return (
        <div className="card">
            <div className="media-content">
            <h1 className="title">Title: {productName}</h1>
            <input className="input is-warning" type="text" placeholder="Warning input"/>
            <div>Product description to be defined</div>
            <div>{price}</div>
            {/*chci li volat funkci s parametrem tka musim udelat volani pres anonym dci*/
            /*<button onClick={ onClickHandler}>Buy</button>*/}
                <button className="button is-success " onClick={()=> onClickHandler(productName)}>Buy</button>
        </div>
        </div>
    )
}

export default Product;