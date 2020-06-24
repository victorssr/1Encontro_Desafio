import { Context } from 'fabric-contract-api';
import { ChaincodeStub, ClientIdentity } from 'fabric-shim';
import { CasamentoContract } from '.';

import * as chai from 'chai';
import * as chaiAsPromised from 'chai-as-promised';
import * as sinon from 'sinon';
import * as sinonChai from 'sinon-chai';
import winston = require('winston');

chai.should();
chai.use(chaiAsPromised);
chai.use(sinonChai);

class TestContext implements Context {
    public stub: sinon.SinonStubbedInstance<ChaincodeStub> = sinon.createStubInstance(ChaincodeStub);
    public clientIdentity: sinon.SinonStubbedInstance<ClientIdentity> = sinon.createStubInstance(ClientIdentity);
    public logging = {
        getLogger: sinon.stub().returns(sinon.createStubInstance(winston.createLogger().constructor)),
        setLevel: sinon.stub(),
     };
}

describe('CasamentoContract', () => {

    let contract: CasamentoContract;
    let ctx: TestContext;

    beforeEach(() => {
        contract = new CasamentoContract();
        ctx = new TestContext();
        ctx.stub.getState.withArgs('1001').resolves(Buffer.from('{"value":"casamento 1001 value"}'));
        ctx.stub.getState.withArgs('1002').resolves(Buffer.from('{"value":"casamento 1002 value"}'));
    });

    describe('#casamentoExists', () => {

        it('should return true for a casamento', async () => {
            await contract.casamentoExists(ctx, '1001').should.eventually.be.true;
        });

        it('should return false for a casamento that does not exist', async () => {
            await contract.casamentoExists(ctx, '1003').should.eventually.be.false;
        });

    });

    // describe('#createCasamento', () => {

    //     it('should create a casamento', async () => {
    //         await contract.createCasamento(ctx, '1003', 'casamento 1003 value');
    //         ctx.stub.putState.should.have.been.calledOnceWithExactly('1003', Buffer.from('{"value":"casamento 1003 value"}'));
    //     });

    //     it('should throw an error for a casamento that already exists', async () => {
    //         await contract.createCasamento(ctx, '1001', 'myvalue').should.be.rejectedWith(/The casamento 1001 already exists/);
    //     });

    // });

    // describe('#readCasamento', () => {

    //     it('should return a casamento', async () => {
    //         await contract.readCasamento(ctx, '1001').should.eventually.deep.equal({ value: 'casamento 1001 value' });
    //     });

    //     it('should throw an error for a casamento that does not exist', async () => {
    //         await contract.readCasamento(ctx, '1003').should.be.rejectedWith(/The casamento 1003 does not exist/);
    //     });

    // });

    // describe('#updateCasamento', () => {

    //     it('should update a casamento', async () => {
    //         await contract.updateCasamento(ctx, '1001', 'casamento 1001 new value');
    //         ctx.stub.putState.should.have.been.calledOnceWithExactly('1001', Buffer.from('{"value":"casamento 1001 new value"}'));
    //     });

    //     it('should throw an error for a casamento that does not exist', async () => {
    //         await contract.updateCasamento(ctx, '1003', 'casamento 1003 new value').should.be.rejectedWith(/The casamento 1003 does not exist/);
    //     });

    // });

    // describe('#deleteCasamento', () => {

    //     it('should delete a casamento', async () => {
    //         await contract.deleteCasamento(ctx, '1001');
    //         ctx.stub.deleteState.should.have.been.calledOnceWithExactly('1001');
    //     });

    //     it('should throw an error for a casamento that does not exist', async () => {
    //         await contract.deleteCasamento(ctx, '1003').should.be.rejectedWith(/The casamento 1003 does not exist/);
    //     });

    // });

});
