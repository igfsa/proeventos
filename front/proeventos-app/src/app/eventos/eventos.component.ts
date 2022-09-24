import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { BsDropdownConfig } from 'ngx-bootstrap/dropdown';
import { ConnectableObservable } from 'rxjs';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
  providers: [{ provide: BsDropdownConfig, useValue: { isAnimated: true} }],

  // eslint-disable-next-line @angular-eslint/component-selector
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  // É necessário declarar um valor vazio para eventos pois quando formos fazer o acesso aos dados e usarmos a propriedade length, a mesma precisará ter um valor para referência
  public eventosFiltrados : any = [];

  larguraImagem: number = 100;
  margemImagem: number = 2;
  exibirImagem: boolean = true;

  private _filtraId: boolean = false;
  private _filtraTema: boolean = true;
  private _filtraLocal: boolean = true;
  private _filtraData: boolean = true;
  private _filtraQtd: boolean = true;
  private _filtraLote: boolean = true;
  // As variáveis privadas são criadas devida a necessidade de getters e setters para conseguir fazer a interpolação. Caso não seja feita a configuração dos getters e setters, o valor não é corretamente passado para a variável

  Id: string = '';
  Tema: string = '';
  Local: string = '';
  Data: string = '';
  Qtd: string = '';
  Lote: string = '';

  private _filtroLista: string = '';

  public get filtroLista(): string{
    return this._filtroLista;
  }

  public set filtroLista(valor: string){
    this._filtroLista = valor;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
    // Não podemos atribuir this.eventos diretamente para this.eventos pois ao usarmos o filtro eventos assume um valor, e apos ser utilizado, sera retornado esse mesmo valor
  }

  public get filtraId(): boolean{
    return this._filtraId;
  }

  public set filtraId(valor: boolean){
    this._filtraId = valor;
  }

  public get filtraTema(): boolean{
    return this._filtraTema;
  }

  public set filtraTema(valor: boolean){
    this._filtraTema = valor;
  }

  public get filtraLocal(): boolean{
    return this._filtraLocal;
  }

  public set filtraLocal(valor: boolean){
    this._filtraLocal = valor;
  }

  public get filtraData(): boolean{
    return this._filtraData;
  }

  public set filtraData(valor: boolean){
    this._filtraData = valor;
  }

  public get filtraQtd(): boolean{
    return this._filtraQtd;
  }

  public set filtraQtd(valor: boolean){
    this._filtraQtd = valor;
  }

  public get filtraLote(): boolean{
    return this._filtraLote;
  }

  public set filtraLote(valor: boolean){
    this._filtraLote = valor;
  }

  private _tipoFiltro: any;

  public get tipoFiltro(): tipoFiltro{
    return this._tipoFiltro = new tipoFiltro(this.filtraId, this.filtraTema, this.filtraLocal, this.filtraData, this.filtraQtd, this.filtraLote);
  }

  public set tipoFiltro(valor: tipoFiltro){
    this._tipoFiltro = valor;
  }




  public filtrarEventos(filtrarPor: string) : any
  {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter
    (
      (evento:
        {
          tema: string;
          local: string;
          dataEvento: string;
          qtdPessoas: string;
          lote: string;
          eventoId: string;
        }) =>(
            (this.tipoFiltro.filtraTema ? evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 : 0)
            || (this.tipoFiltro.filtraLocal ? evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1 : 0)
            || (this.tipoFiltro.filtraData ? evento.dataEvento.toLocaleLowerCase().indexOf(filtrarPor) !== -1 : 0)
            || (this.tipoFiltro.filtraQtd ? evento.qtdPessoas.toString().toLocaleLowerCase().indexOf(filtrarPor) !== -1 : 0)
            || (this.tipoFiltro.filtraLote ? evento.lote.toString().toLocaleLowerCase().indexOf(filtrarPor) !== -1 : 0)
            || (this.tipoFiltro.filtraId ? evento.eventoId.toString().toLocaleLowerCase().indexOf(filtrarPor) !== -1 : 0)
        )
    )
  }


  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.GetEventos();
  }

  alterarImagem(){
    this.exibirImagem = !this.exibirImagem;
  }

  clickFiltrarEventos(){
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  public GetEventos (): void{
    this.http.get('https://localhost:7136/api/Eventos/GetAll').subscribe({
      next: (r) =>
      {
        this.eventos = r;
        this.eventosFiltrados = this.eventos;
      },
      error: (e) => console.log(e)
    })

    // this.eventos = [
    //   {
    //     tema: `festa`,
    //     local: `Cidade`
    //   },
    //   {
    //     tema: `reunião`,
    //     local: `Outra cidade`
    //   },
    //   {
    //     tema: `reunião`,
    //     local: `Cidade`
    //   },
    //   {
    //     tema: `Festa`,
    //     local: `Outra cidade`
    //   }
    // ]
  }
}

class tipoFiltro
{
  filtraId: boolean;
  filtraTema: boolean;
  filtraLocal: boolean;
  filtraData: boolean;
  filtraQtd: boolean;
  filtraLote: boolean;

  constructor(filtraId: boolean, filtraTema: boolean, filtraLocal: boolean, filtraData: boolean, filtraQtd: boolean, filtraLote: boolean)
  {
    this.filtraId = filtraId;
    this.filtraTema = filtraTema;
    this.filtraLocal = filtraLocal;
    this.filtraData = filtraData;
    this.filtraQtd = filtraQtd;
    this.filtraLote = filtraLote;
  }
}

