import React from 'react';

export default function Tabela({ data }) {
  const colunas = data[0] && Object.keys(data[0])
 return (
   <table cellPadding={0} cellSpacing={0}> 
     <thead>
       <tr>{data[0] && colunas.map((dados) => <th>{dados}</th>)}</tr>
     </thead>

      <tbody>
  	      {
            data.map((row) => (
              <tr>
                {colunas.map((colunas) => (
                  <td>{row[colunas]}</td>
                ))}
              </tr>
            ))
          }
      </tbody>
   </table>
 );
}