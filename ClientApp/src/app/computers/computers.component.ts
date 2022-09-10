import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Computer } from '../models/computer';
import { ComputerService } from '../service/computer.service';

@Component({
  selector: 'app-computers',
  templateUrl: './computers.component.html',
  styleUrls: ['./computers.component.css'],
})
export class ComputersComponent implements OnInit {
  constructor(
    private computerService: ComputerService,
    private fb: FormBuilder
  ) {
    this.createForm();
    this.createSearchForm();
  }

  ngOnInit() {
    this.loadComputers();
  }

  public computerForm: FormGroup;
  public searchForm: FormGroup;
  public title = 'Computadores';
  public selectedComputer: Computer;
  public computers: Computer[];
  public computer: Computer;
  public modeSave = 'post';

  selectComputer(computer: Computer) {
    this.modeSave = 'put';
    this.selectedComputer = computer;
    this.computerForm.patchValue(computer);
  }

  back() {
    this.selectedComputer = null;
  }

  createSearchForm() {
    this.searchForm = this.fb.group({
      query: ['', Validators.required],
    });
  }

  createForm() {
    this.computerForm = this.fb.group({
      id: [0],
      marca: ['', Validators.required],
      modelo: ['', Validators.required],
      placaMae: ['', Validators.required],
      memoriaRam: ['', Validators.required],
      armazenamento: ['', Validators.required],
      velocidadeProcessador: ['', Validators.required],
    });
  }

  computerSubmit() {
    this.saveComputer(this.computerForm.value);
  }

  searchSubmit() {
    this.searchComputer(this.searchForm.value['query']);
  }

  searchComputer(query: string) {
    this.computerService.getSearchComputers(query).subscribe(
      (computers: Computer[]) => {
        this.computers = computers;
      },
      (err: any) => {
        console.error(err);
      }
    );
  }

  loadComputers() {
    this.computerService.getAllComputers().subscribe(
      (computers: Computer[]) => {
        this.computers = computers;
      },
      (err: any) => {
        console.error(err);
      }
    );
  }

  saveComputer(pc: Computer) {
    pc.id <= 0 ? (this.modeSave = 'post') : (this.modeSave = 'put');

    this.computerService[this.modeSave](pc).subscribe(
      (r: Computer) => {
        console.log(r);
        this.loadComputers();
      },
      (err: any) => {
        console.log(err);
      }
    );
  }

  deleteComputer(pc: Computer) {
    this.computerService.delete(pc.id).subscribe(
      (r: Computer) => {
        console.log('Removido');
        this.loadComputers();
      },
      (err: any) => {
        console.log(err);
      }
    );
  }
}
