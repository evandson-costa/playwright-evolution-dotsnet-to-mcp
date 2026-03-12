import React, { useState } from 'react';
import axios from 'axios';
import './App.css';

function App() {
  const [formData, setFormData] = useState({ nome: '', email: '', cep: '', rua: '', bairro: '', cidade: '' });
  const [loading, setLoading] = useState(false);

  const handleCepBlur = async () => {
    if (formData.cep.length === 8) {
      setLoading(true);
      try {
        const response = await axios.get(`http://localhost:5138/api/usuarios/cep/${formData.cep}`);
        const { logradouro, bairro, localidade } = response.data;

        setFormData({ ...formData, rua: logradouro, bairro: bairro, cidade: localidade });
      } catch (error) {
        console.error("Erro ao buscar CEP:", error);
      } finally {
        setLoading(false);
      }
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await axios.post('http://localhost:5138/api/usuarios', formData);
      alert("Usuário salvo no SQL Server com sucesso!");
      // eslint-disable-next-line no-unused-vars
    } catch (error) {
      alert("Erro ao salvar usuário.");
    }
  };

  return (
    <div className="container">
      <h1>Cadastro de Usuário - MBA IA</h1>
      <form onSubmit={handleSubmit}>
        <div className="field">
          <label>Nome:</label>
          <input type="text" onChange={e => setFormData({ ...formData, nome: e.target.value })} />
        </div>

        <div className="field">
          <label>Email:</label>
          <input type="email" onChange={e => setFormData({ ...formData, email: e.target.value })} />
        </div>
                
        <div className="field">
          <label htmlFor="cep-input">CEP:</label>
          <div style={{ display: 'flex', gap: '8px' }}>
            <input
              type="text"
              id="cep-input"
              placeholder="97015373"
              value={formData.cep}
              onChange={e => setFormData({ ...formData, cep: e.target.value })}
            />
            <button
              type="button"
              onClick={handleCepBlur} // Reaproveita a função de busca
              className="btn-search"
              disabled={loading}
            >
              {loading ? '...' : '🔍'}
            </button>
          </div>
          {loading && <span className="loading-text">Buscando na API C#...</span>}
        </div>

        <div className="field">
          <label>Rua:</label>
          <input type="text" value={formData.rua} readOnly className="readonly-field" />
        </div>
        <div className="field">
          <label>Bairro:</label>
          <input type="text" value={formData.bairro} readOnly className="readonly-field" />
        </div>
         <div className="field">
          <label>Cidade:</label>
          <input type="text" value={formData.cidade} readOnly className="readonly-field" />
        </div>

        <button type="submit">Salvar no Banco</button>
      </form>
    </div>
  );
}

export default App;