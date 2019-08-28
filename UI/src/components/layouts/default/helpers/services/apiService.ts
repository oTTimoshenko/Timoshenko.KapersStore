import axios from 'axios';
const apiBaseUrl = process.env.API_BASE_URL;

class ApiService {
  public get(controller: string, method: string,) {
    const url = `${apiBaseUrl}/${controller}/${method}`;

    const response = axios.get(url);

    return response;
  }

  public post(controller: string, method: string, bodyData: any) {
    const url = `${apiBaseUrl}/${controller}/${method}`;

    const response = axios.post(url, bodyData || {});

    return response;
  }
}

const apiService = new ApiService();

export default apiService;