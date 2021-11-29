import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Container, Row, Col, Table, Tab, Tabs, Form, Button } from 'react-bootstrap';

export default function Home() {
    const [fisicos, setFisicos] = useState([]);
    const [juridicos, setJuridicos] = useState([]);
    const [empresas, setEmpresas] = useState([]);

    const [search, setSearch] = useState("");
    const [search2, setSearch2] = useState("");

    
    const [ isLoading , setIsLoading ] = useState( false );
    const [ nome , setNome ] = useState( '' );
    const [ empresa , setEmpresa ] = useState( '' );
    const [ cpf , setCPF ] = useState( '' )
    const [ rg , setRG ] = useState( '' );
    const [ cnpj , setCNPJ ] = useState( '' );
    const [ dataNascimento , setDataNacimento ] = useState( '' );

    const [ uf , setUF] = useState( '' );
    const [ nomeFantasia , setNomeFantasia ] = useState( '' );
  


    function buscarFisico(){
        axios('https://localhost:5001/v1/Fisico')
        .then(resposta => {
            if (resposta.status === 200) {
                setFisicos(resposta.data.data);
            }
        })
        .catch(erro => console.log(erro));
    }

    useEffect( buscarFisico, [] );

    function buscarJuridico(){
        axios('https://localhost:5001/v1/Juridico')
        .then(resposta => {
            if (resposta.status === 200) {
                setJuridicos(resposta.data.data);
            }
            
        })
        .catch(erro => console.log(erro));
    }

    useEffect( buscarJuridico, [] );

    function Empresas(){
        

        axios('https://localhost:5001/v1/empresa')
        .then(resposta => {
            if (resposta.status === 200) {
                setEmpresas(resposta.data.data);
                console.log(resposta.data.data);
            }
            
        })
        .catch(erro => console.log(erro));
    }

    useEffect( Empresas, [] );
    
    function CadastrarFisico(event){

        event.preventDefault();

        setIsLoading( true );


        axios
            .post('https://localhost:5001/v1/Fisico', {
  
            nome : nome,
            idEmpresa : empresa,
            rg : rg,
            cpf : cpf,
            dataNascimento : dataNascimento
      
        })
        .then(res => {
            if (res.status === 200) {
                console.log(res.data);
                setIsLoading( false );
                console.log(isLoading);
                limpaStates();
                buscarFisico();
            }
        })
        
        .catch(error => console.log(error));
    }

    function CadastrarJuridico(event){

        event.preventDefault();

        setIsLoading( true );


        axios
            .post('https://localhost:5001/v1/Juridico', {
  
            nome : nome,
            cnpj : cnpj,
            idEmpresa : empresa

      
        })
        .then(res => {
            if (res.status === 200) {
                console.log(res.data);
                setIsLoading( false );
                console.log(isLoading);
                buscarJuridico();
                limpaStates();
            }
        })
        
        .catch(error => console.log(error));
    }

    function CadastrarEmpresa(event){

        setIsLoading( true );


        axios
            .post('https://localhost:5001/v1/empresa', {
  
            uf : uf,
            nomeFantasia : nomeFantasia,
            cnpj : cnpj

      
        })
        .then(res => {
            if (res.status === 200) {
                console.log(res.data);
                setIsLoading( false );
                console.log(isLoading);
                empresas();
                limpaStates();
            }
        })
        
        .catch(error => console.log(error));
    }

    function limpaStates(){
            setNome( '' );
            setEmpresa( '' );
            setCPF( '' );
            setRG( '' );
            setCNPJ( '' );
            setDataNacimento( '' );
            setUF('');
            setNomeFantasia( '' );

        }
            

 return (
    <Container>
        <Row>
            <h2>Cadastro</h2>
            <Tabs defaultActiveKey="fisico" id="uncontrolled-tab-example" className="mb-3">
                <Tab eventKey="fisico" title="Físico">
                    
                <Form  onSubmit={CadastrarFisico} >
                 <p>Cadastro fornecedor físico</p>
                    <Row className="mb-3">
                        {/* NOME DO FORNECEDOR */}
                        <Form.Group as={Col} controlId="formBasicEmail">
                            <Form.Label>Nome</Form.Label>
                            <Form.Control 
                            type="Text" 
                            placeholder="ex: Matheus "
                            onChange={(event) => setNome(event.target.value)} />
                        </Form.Group>

                        {/* Empresa */}
                        <Form.Group as={Col} controlId="formGridState">
                            <Form.Label>Empresa</Form.Label>
                            <Form.Select 
                            defaultValue="Selecione o tipo de distribuição"
                            onChange={(event) => setEmpresa(event.target.value)}
                            >
                                <option value="0">Selecione uma empresa</option>

                                {
                                    empresas.map(  m => {
                                        return(
                                                        
                                            <option
                                                key={m.id}
                                                value={m.id}
                                                >
                                                {m.nomeFantasia} 
                                                </option>
                                            );
                                    })
                                }
                            </Form.Select>
                        </Form.Group>
                    </Row>

                    <Row className="mb-3">
                        {/* RG */}
                        <Form.Group as={Col} controlId="formBasicEmail">
                            <Form.Label>RG</Form.Label>
                            <Form.Control 
                            type="Text" 
                            placeholder="Ex: 123456-5" 
                            onChange={(event) => setRG(event.target.value)}
                            />
                        </Form.Group>

                        {/* CPF */}
                        <Form.Group as={Col} controlId="formBasicEmail">
                            <Form.Label>CPF</Form.Label>
                            <Form.Control 
                            type="Text" 
                            placeholder="Ex: 123.456.789" 
                            onChange={(event) => setCPF(event.target.value)}
                            />
                        </Form.Group>

                         {/* DATA NASCUMENTO */}
                        <Form.Group as={Col} controlId="formBasicEmail">
                            <Form.Label>Data de nascimento</Form.Label>
                            <Form.Control 
                            type="Date"
                            onChange={(event) => setDataNacimento(event.target.value)}
                            />
                        </Form.Group>
                        
                    </Row>

                    <Button variant="dark" type="submit">
                        Cadastrar
                    </Button>
                </Form>

                </Tab>
                <Tab eventKey="juridico" title="Jurídico">

                <Form onSubmit={CadastrarJuridico}>
                    <p>Cadastro fornecedor jurídico</p>
                    <Row className="mb-3">
                        {/* NOME DO FORNECEDOR */}
                        <Form.Group as={Col} controlId="formBasicEmail">
                            <Form.Label>Nome</Form.Label>
                            <Form.Control 
                            type="Text" 
                            placeholder="ex: Matheus"
                            onChange={(event) => setNome(event.target.value)}
                            />
                            
                        </Form.Group>

                        {/* Empresa */}
                        <Form.Group as={Col} controlId="formGridState">
                            <Form.Label>Empresa</Form.Label>
                            <Form.Select 
                            defaultValue="Selecione o tipo de distribuição"
                            onChange={(event) => setEmpresa(event.target.value)}
                            >
                                <option value="0">Selecione uma empresa</option>

                                {
                                    empresas.map(  m => {
                                        return(
                                                        
                                            <option
                                                key={m.id}
                                                value={m.id}
                                                >
                                                {m.nomeFantasia} 
                                                </option>
                                            );
                                    })
                                }
                            </Form.Select>
                        </Form.Group>

                        {/* CNPJ */}
                        <Form.Group as={Col} controlId="formBasicEmail">
                            <Form.Label>CNPJ</Form.Label>
                            <Form.Control 
                            type="Text" 
                            placeholder="Ex: 992.778/0001-50" 
                            onChange={(event) => setCNPJ(event.target.value)}
                            />
                        </Form.Group>
                    </Row>

                    <Button variant="dark" type="submit">
                        Cadastrar
                    </Button>
                </Form>


                </Tab>
                <Tab eventKey="empresa" title="Empresa">
                <Form onSubmit={CadastrarEmpresa}>
                    <p>Cadastro de empresas</p>
                    <Row className="mb-3">
                        {/* UF */}
                        <Form.Group as={Col} controlId="formBasicEmail">
                            <Form.Label>UF</Form.Label>
                            <Form.Control 
                            type="Text" 
                            placeholder="ex: SP"
                            onChange={(event) => setUF(event.target.value)}
                            />
                            
                        </Form.Group>

                        {/* Nome fantasia */}
                        <Form.Group as={Col} controlId="formBasicEmail">
                            <Form.Label>Nome Fantasia</Form.Label>
                            <Form.Control 
                            type="Text" 
                            placeholder="ex: Padaria Juliana"
                            onChange={(event) => setNomeFantasia(event.target.value)}
                            />
                            
                        </Form.Group>

                        

                        {/* CNPJ */}
                        <Form.Group as={Col} controlId="formBasicEmail">
                            <Form.Label>CNPJ</Form.Label>
                            <Form.Control 
                            type="Text" 
                            placeholder="Ex: 992.778/0001-50" 
                            onChange={(event) => setCNPJ(event.target.value)}
                            />
                        </Form.Group>
                    </Row>

                    <Button variant="dark" type="submit">
                        Cadastrar
                    </Button>
                </Form>

                </Tab>
            </Tabs>    
        </Row>

        <Row>

            <Col>
                <h1>Tabela Fornecedor físico</h1>
                <Row>
                    <div className="container-input-search">
                        <p>Aplique o filtro no campo abaixo Nome, CPF ou Data de cadastro </p>
                        <input 
                        type="text"
                        placeholder="Filtros"
                        className="form-control"
                        style={{ marginTop: 20, marginBottom: 20 ,width: "20%" }}
                        onChange={(e) => {
                            setSearch(e.target.value);
                        }}
                        />
                    </div>

                </Row>
                <Table striped bordered hover variant="dark" >
                    <thead>
                        <tr>
                            <th>Nome</th>
                            <th>Empresa</th>
                            <th>Data de cadastro</th>
                            <th>CPF</th>
                            <th>RG</th>
                            <th>Data de nascimento</th>
                            <th>Contatos</th>

                        </tr>
                    </thead>
                    <tbody>
                            {
                             fisicos.filter((val) => {
                                 if (search === "") {
                                     return val;
                                 }else if(
                                     val.nome.toLowerCase().includes(search.toLowerCase()) ||
                                     val.dataCadastro.toLowerCase().includes(search.toLowerCase()) ||
                                     val.cpf.toLowerCase().includes(search.toLowerCase())
                                     
                                 ){
                                     return val
                                 }
                             })
                             .map((funcio) => {
                                 return(
                                    <tr key={funcio.id}>
                                        <td>{funcio.nome}</td>
                                        <td>{funcio.empresa}</td>
                                        <td>{funcio.dataCadastro}</td>
                                        <td>{funcio.cpf}</td>
                                        <td>{funcio.rg}</td>
                                        <td>{funcio.dataNascimento}</td>      
                                        <td>{funcio.telefones}</td>
                                    </tr>
                                 )
                             })   
                            } 

                    </tbody>
                </Table>
            
            </Col>

            

            <Col>
                <h1>Fornecedores jurídicos</h1>
                <Row>
                    <div className="container-input-search">
                        <p>Aplique o filtro no campo abaixo Nome, CNPJ ou Data de cadastro </p>
                        <input 
                        type="Filtros"
                        placeholder="Filtrar por nome"
                        className="form-control"
                        style={{ marginTop: 20, marginBottom: 20 ,width: "20%" }}
                        onChange={(e) => {
                            setSearch2(e.target.value);
                        }}
                        />
                    </div>     
                </Row>

                <Table striped bordered hover variant="dark" >
                    <thead>
                        <tr>
                            <th>Nome</th>
                            <th>Empresa</th>
                            <th>Data de cadastro</th>
                            <th>CNPJ</th>
                            <th>Contatos</th>
                        </tr>
                    </thead>

                    <tbody>
                            {
                             juridicos.filter((val) => {
                                 if (search2 === "") {
                                     return val;
                                 }else if(
                                     val.nome.toLowerCase().includes(search2.toLowerCase()) ||
                                     val.cnpj.toLowerCase().includes(search2.toLowerCase()) ||
                                     val.dataCadastro.toLowerCase().includes(search2.toLowerCase())
                                     
                                 ){
                                     return val
                                 }
                             })
                             .map((funcio) => {
                                 return(
                                    <tr key={funcio.id}>
                                        <td>{funcio.nome}</td>
                                        <td>{funcio.empresa}</td>
                                        <td>{funcio.dataCadastro}</td>
                                        <td>{funcio.cnpj}</td> 
                                        <td>{funcio.telefones}</td>
                                    </tr>
                                 )
                             })   
                            } 

                    </tbody>
                
                </Table>
            
            </Col>
        </Row>
    </Container>
 );
}