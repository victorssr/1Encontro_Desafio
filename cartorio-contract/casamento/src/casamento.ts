import { Object, Property } from 'fabric-contract-api';
import { Pessoa } from './pessoa';

@Object()
export class Casamento {

    public juiz: Pessoa;

    public primeiroNoivo: Pessoa;

    public segundoNoivo: Pessoa;

    public primeiraTestemunha: Pessoa;

    public segundaTestemunha: Pessoa;

    public dataEntrada: Date;

    public dataEntradaAprovada: Date;

    public dataCasamento: Date;

    public dataCasamentoRealizado: Date;

    public linkCerimonia: string;

    public dataCasamentoAprovado: Date;
    
}
