import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { BsDropdownConfig } from 'ngx-bootstrap/dropdown';

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

  filtraId: boolean = true;
  filtraTema: boolean = true;
  filtraLocal: boolean = true;
  filtraData: boolean = true;
  filtraQtd: boolean = true;
  filtraLote: boolean = true;

  private _filtroLista: string = '';

  public get filtroLista(): string{
    return this._filtroLista;
  }

  public set filtroLista(valor: string){
    this._filtroLista = valor;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
    // Não podemos atribuir this.eventos diretamente para this.eventos pois ao usarmos o filtro eventos assume um valor, e apos ser utilizado, sera retornado esse mesmo valor
  }

  filtrarEventos(filtraPor: string) : any
  {
    filtraPor = filtraPor.toLocaleLowerCase();

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
            evento.tema.toLocaleLowerCase().indexOf(filtraPor) !== -1
            || evento.local.toLocaleLowerCase().indexOf(filtraPor) !== -1
            || evento.dataEvento.toLocaleLowerCase().indexOf(filtraPor) !== -1
            || evento.qtdPessoas.toString().toLocaleLowerCase().indexOf(filtraPor) !== -1
            || evento.lote.toString().toLocaleLowerCase().indexOf(filtraPor) !== -1
            || evento.eventoId.toString().toLocaleLowerCase().indexOf(filtraPor) !== -1
        )
    )
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.GetEventos();
  }

  alterarImagem(){
    this.exibirImagem = !this.exibirImagem
  }

  public GetEventos (): void{
    this.http.get('https://localhost:7136/api/Eventos').subscribe({
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
