import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:5042/'
});

// Interceptor de REQUEST – já está certinho
api.interceptors.request.use(
  config => {
    const token = localStorage.getItem('token');
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  error => Promise.reject(error)
);

// 👇 Interceptor de RESPONSE – adiciona esse trecho abaixo
api.interceptors.response.use(
  response => response,
  error => {
    const msg =
      error.response?.data?.message || // se a API retorna { message: "..." }
      error.response?.data ||          // se a API retorna string
      'Erro inesperado';
    return Promise.reject(new Error(msg));
  }
);

export default api;
