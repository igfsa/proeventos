import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { BsDropdownConfig } from 'ngx-bootstrap/dropdown';

@Component({
  selector: 'app-categorias',
  templateUrl: './categorias.component.html',
  styleUrls: ['./categorias.component.scss'],
  providers: [{ provide: BsDropdownConfig, useValue: { isAnimated: true} }],
})
export class CategoriasComponent implements OnInit {

  public categorias: any = [];
  public categoriasFiltradas : any = [];

  private _filtraId: boolean = false;
  private _filtraNome: boolean = true;

  Id: string = '';
  Nome: string = '';

  private _filtroLista: string = '';

  public get filtroLista(): string{
    return this._filtroLista;
  }

  public set filtroLista(valor: string){
    this._filtroLista = valor;
    this.categoriasFiltradas = this.filtroLista ? this.filtrarCategorias(this.filtroLista) : this.categorias;
  }

  public get filtraId(): boolean{
    return this._filtraId;
  }

  public set filtraId(valor: boolean){
    this._filtraId = valor;
  }

  public get filtraNome(): boolean{
    return this._filtraNome;
  }

  public set filtraNome(valor: boolean){
    this._filtraNome = valor;
  }

  private _tipoFiltro: any;

  public get tipoFiltro(): tipoFiltro{
    return this._tipoFiltro = new tipoFiltro(this.filtraId, this.filtraNome);
  }

  public set tipoFiltro(valor: tipoFiltro){
    this._tipoFiltro = valor;
  }

  public filtrarCategorias(filtrarPor: string) : any
  {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.categorias.filter
    (
      (categoria:
        {
          nome: string;
          categoriaId: string;
        }) =>(
            (this.tipoFiltro.filtraNome ? categoria.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1 : 0)
           || (this.tipoFiltro.filtraId ? categoria.categoriaId.toString().toLocaleLowerCase().indexOf(filtrarPor) !== -1 : 0)
        )
    )
  }



  constructor(private http: HttpClient) { }

  ngOnInit()
  {
    this.GetCategorias();
  }

  clickFiltrarCategorias()
  {
    this.categoriasFiltradas = this.filtroLista ? this.filtrarCategorias(this.filtroLista) : this.categorias;
  }



  public GetCategorias (): void
  {
    this.http.get('https://localhost:7136/api/Categorias/GetAll').subscribe({
      next: (r) =>
      {
        this.categorias = r;
        this.categoriasFiltradas = this.categorias;
      },
      error: (e) => console.log(e)
    })
  }
}

class tipoFiltro
{
  filtraId: boolean;
  filtraNome: boolean;


  constructor(filtraId: boolean, filtraNome: boolean)
  {
    this.filtraId = filtraId;
    this.filtraNome = filtraNome;
  }
}
