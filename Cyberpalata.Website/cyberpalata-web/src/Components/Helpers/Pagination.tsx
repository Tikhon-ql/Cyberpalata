import React from 'react';

export const Pagination = ({
    pageCount,
    curPage,
    setCurPage,
    totalItemsCount
}: any) =>
{
    var pages:number[] = [];
    for(var i:number = 1; i <= Math.ceil(totalItemsCount / pageCount);i++)
    {
        pages.push(i);
    }
    console.dir(pages);
    return(

        <ul className="pagination mt-2">
            {pages.map((page,index) => {

                return <li key={index} onClick={()=>{setCurPage(page)}} className = {page == curPage? 'page-item active' : 'page-item'}><a className="page-link">{page}</a></li>
            })}
        </ul>
    )
};