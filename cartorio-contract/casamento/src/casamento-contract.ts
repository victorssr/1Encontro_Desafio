import { Context, Contract, Info, Returns, Transaction } from 'fabric-contract-api';
import { Casamento } from './casamento';
import { Pessoa } from './pessoa';

@Info({ title: 'CasamentoContract', description: 'My Smart Contract' })
export class CasamentoContract extends Contract {

    @Transaction(false)
    @Returns('boolean')
    public async casamentoExists(ctx: Context, casamentoId: string): Promise<boolean> {
        const buffer = await ctx.stub.getState(casamentoId);
        return (!!buffer && buffer.length > 0);
    }

    @Transaction(false)
    @Returns('boolean')
    public async validarPessoaCasamento(pessoaJson: string): Promise<boolean> {
        // VALIDA SE A PESSOA ESTÁ DESIMPEDIDA
        return true;
    }

    @Transaction()
    public async solicitarEntradaCasamento(ctx: Context, casamentoId: string, primeiroNoivoJson: string, segundoNoivoJson: string,
        primeiraTestemunhaJson: string, segundaTestemunhaJson: string): Promise<void> {

        const exists = await this.casamentoExists(ctx, casamentoId);
        if (exists) {
            throw new Error(`A entrada do casamento ${casamentoId} já foi solicitada.`);
        }

        const casamento = new Casamento();
        casamento.primeiroNoivo = JSON.parse(primeiroNoivoJson) as Pessoa;
        casamento.segundoNoivo = JSON.parse(segundoNoivoJson) as Pessoa;
        casamento.primeiraTestemunha = JSON.parse(primeiraTestemunhaJson) as Pessoa;
        casamento.segundaTestemunha = JSON.parse(segundaTestemunhaJson) as Pessoa;
        casamento.dataEntrada = new Date();

        const buffer = Buffer.from(JSON.stringify(casamento));
        await ctx.stub.putState(casamentoId, buffer);
    }

    @Transaction()
    public async aprovaEntradaCasamento(ctx: Context, casamentoId: string): Promise<void> {
        const exists = await this.casamentoExists(ctx, casamentoId);
        if (!exists) {
            throw new Error(`O casamento ${casamentoId} não foi registrado.`);
        }

        const bufferCasamento = await ctx.stub.getState(casamentoId);
        const casamento = JSON.parse(bufferCasamento.toString()) as Casamento;
        casamento.dataEntradaAprovada = new Date();

        const buffer = Buffer.from(JSON.stringify(casamento));
        await ctx.stub.putState(casamentoId, buffer);
    }

    @Transaction(false)
    @Returns('Date')
    public async verificaEntradaCasamento(ctx: Context, casamentoid: string): Promise<Date> {
        const exists = await this.casamentoExists(ctx, casamentoid);
        if (!exists) {
            throw new Error(`O casamento ${casamentoid} não foi registrado.`);
        }

        const buffer = await ctx.stub.getState(casamentoid);
        const casamentoCartorioGovBr = JSON.parse(buffer.toString()) as Casamento;
        return casamentoCartorioGovBr.dataEntradaAprovada;
    }

    @Transaction()
    public async defineDataCasamento(ctx: Context, casamentoId: string, dataCasamento: string): Promise<void> {
        const exists = await this.casamentoExists(ctx, casamentoId);
        if (!exists) {
            throw new Error(`O casamento ${casamentoId} não foi registrado.`);
        }

        const bufferCasamento = await ctx.stub.getState(casamentoId);
        const casamento = JSON.parse(bufferCasamento.toString()) as Casamento;
        casamento.dataCasamento = new Date(dataCasamento);

        const buffer = Buffer.from(JSON.stringify(casamento));
        await ctx.stub.putState(casamentoId, buffer);
    }

    @Transaction()
    public async defineRealizacaoCasamento(ctx: Context, casamentoId: string, dataRealizacao: string, linkCerimonia: string): Promise<void> {
        const exists = await this.casamentoExists(ctx, casamentoId);
        if (!exists) {
            throw new Error(`O casamento ${casamentoId} não foi registrado.`);
        }

        const bufferCasamento = await ctx.stub.getState(casamentoId);
        const casamento = JSON.parse(bufferCasamento.toString()) as Casamento;
        casamento.dataCasamentoRealizado = new Date(dataRealizacao);
        casamento.linkCerimonia = linkCerimonia;

        const buffer = Buffer.from(JSON.stringify(casamento));
        await ctx.stub.putState(casamentoId, buffer);
    }

    @Transaction()
    public async aprovaCasamentoDiarioOficial(ctx: Context, casamentoId: string): Promise<void> {
        const exists = await this.casamentoExists(ctx, casamentoId);
        if (!exists) {
            throw new Error(`O casamento ${casamentoId} não foi registrado.`);
        }

        const bufferCasamento = await ctx.stub.getState(casamentoId);
        const casamento = JSON.parse(bufferCasamento.toString()) as Casamento;
        casamento.dataCasamentoAprovado = new Date();

        const buffer = Buffer.from(JSON.stringify(casamento));
        await ctx.stub.putState(casamentoId, buffer);
    }

    @Transaction(false)
    @Returns('Casamento')
    public async obterCasamento(ctx: Context, casamentoId: string): Promise<Casamento> {
        const exists = await this.casamentoExists(ctx, casamentoId);
        if (!exists) {
            throw new Error(`O casamento ${casamentoId} não foi registrado.`);
        }

        const buffer = await ctx.stub.getState(casamentoId);
        const casamento = JSON.parse(buffer.toString()) as Casamento;
        return casamento;
    }

    @Transaction()
    public async excluirCasamento(ctx: Context, casamentoId: string): Promise<void> {
        const exists = await this.casamentoExists(ctx, casamentoId);
        if (!exists) {
            throw new Error(`O casamento ${casamentoId} não foi registrado.`);
        }
        
        await ctx.stub.deleteState(casamentoId);
    }

}
