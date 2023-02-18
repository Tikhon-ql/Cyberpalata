export const Pagination = ({
    pageCount,
    curPage,
    setCurPage,
    totalItemsCount
}: any) =>
{
    let pages = [];
    for(let i = 1; i <= Math.ceil(totalItemsCount / pageCount);i++)
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