import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface CreateState {

}

export class Create extends React.Component<RouteComponentProps<{}>, CreateState> {
    form: HTMLFormElement | null;

    constructor() {
        super();
        this.state = {
            employmentDate: new Date().toISOString().substring(0, 10),
            firstName: "",
            lastName: "",
            jobId: 1,
            rate: 0
        };
    }

    public componentWillMount(): void {
        this.loadJobs();
    }

    private loadJobs() {
        fetch('api/Employee/GetAllJobs')
            .then(response => response.json() as Promise<JobModel[]>)
            .then(data => {
                this.setState({ jobs: data });
            });
    }

    private addEmployee(e: object) {
        fetch('api/Employee', {
            method: "POST",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(e)
        }).then(response => window.location.href = "/");
    }

    private handleSubmit(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        this.addEmployee({
            EmploymentDate: this.state.employmentDate,
            FirstName: this.state.firstName,
            LastName: this.state.lastName,
            JobId: this.state.jobId,
            Rate: this.state.rate
        });
    }

    public render() {
        return <form ref={e => this.form = e} onSubmit={e => this.handleSubmit(e)}>

            <table>
                <tbody>
                    <tr>
                        <th>First Name</th>
                        <th><input name="FirstName" type="text" maxLength={32} required value={this.state.firstName} onChange={e => this.setState({ firstName: (e || window.event).target.value })} /></th>
                    </tr>
                    <tr>
                        <th>Last Name</th>
                        <th><input name="LastName" type="text" maxLength={32} required value={this.state.lastName} onChange={e => this.setState({ lastName: (e || window.event).target.value })} /></th>
                    </tr>
                    <tr>
                        <th>Employment Date</th>
                        <th><input name="Employment Date" type="date" maxLength={32} required value={this.state.employmentDate} onChange={e => this.setState({ employmentDate: (e || window.event).target.value })} /></th>
                    </tr>
                    <tr>
                        <th>Rate</th>
                        <th><input name="Rate" type="number" required value={this.state.rate} onChange={e => this.setState({ rate: parseFloat((e || window.event).target.value) })} /></th>
                    </tr>
                    <tr>
                        <th>Job title</th>
                        <th><select name="JobId" required value={this.state.jobId} onChange={e => this.setState({ jobId: parseInt((e || window.event).target.value) })} >
                            {this.state.jobs && this.state.jobs.map(j => <option key={j.id} value={j.id}>{j.title}</option>)}
                        </select></th>
                    </tr>
                </tbody>
            </table>
            <input type="button" value="Back" onClick={() => window.location.href = "/"} />
            <input type="submit" value="Submit" />
        </form>
    }


}

interface CreateState extends CreateEmployeeModel {
    jobs?: JobModel[]
}

interface JobModel {
    id: number;
    title: string;
}

interface CreateEmployeeModel {
    firstName: string;
    lastName: string;
    employmentDate: string;
    rate: number;
    jobId: number;
}