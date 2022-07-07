export class Global {
  //static API_URL = 'https://localhost:44314/api/';
  static API_URL = 'https://webapi.emlakofisimden.com/api/';

  static catchMessage = 'A problem occurred, please contact us! medilaw7@gmail.com';
}
export const app = {
  item: JSON.parse(localStorage.getItem('USER')),
  // licenceName: JSON.parse(localStorage.getItem('LICENCENAME'))
};
