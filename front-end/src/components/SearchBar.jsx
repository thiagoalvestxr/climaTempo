import { useEffect, useState } from 'react'
import { AiOutlineClose } from 'react-icons/ai'

import './SearchBar.css'

function SearchBar({ data, callback }) {

    const [inputId, setInputId] = useState(0);
    const [inputSearch, setInputSearch] = useState("")
    const [filterSearch, setFilterSearch] = useState([])

    const handleFilter = (event) => {
        setInputSearch(event.target.value)

        const newFilter = data.filter(value => {
            return value.nome.toLowerCase().includes(inputSearch.toLowerCase())
        })

        setFilterSearch(newFilter)
    }

    useEffect(() => {
        if (inputSearch === "") {
            setFilterSearch([])
        }
    }, [inputSearch])

    function handleClickAutoComplete(value) {
        setInputId(value.id)
        setInputSearch(value.nome)
        setFilterSearch([])
    }

    function clearText() {
        setInputId(0)
        setInputSearch("")
        setFilterSearch([])
    }

    return (
        <div className='search' >
            <div className='searchInputs'>
                <input type="text" placeholder='Digite o nome da cidade para pesquisar' value={inputSearch} onChange={handleFilter} />
                {inputSearch !== "" ? <AiOutlineClose onClick={clearText} /> : ""}
                <button type="button" className="btn btn-dark btn-lg" disabled={inputId === 0} onClick={() => callback(inputId, inputSearch)}>Buscar</button> 
            </div>
            {filterSearch.length > 0 &&
                <div className='dataResult'>
                    {filterSearch.map(value => (
                        <div key={value.id} className='dataItem' onClick={() => handleClickAutoComplete(value)}>
                            <p> {`${value.nome} | ${value.uf}`}</p>
                        </div>
                    ))}
                </div>
            }
        </div>
    )
}

export default SearchBar
