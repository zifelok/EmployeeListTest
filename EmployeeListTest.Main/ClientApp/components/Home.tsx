import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class Home extends React.Component<RouteComponentProps<{}>, HomeState> {
    public componentWillMount(): void {
        this.loadData();
    }

    private loadData() {
        fetch('api/Employee/GetAll')
            .then(response => response.json() as Promise<EmployeeListModel[]>)
            .then(data => {
                this.setState({ employees: data });
            });
        fetch('api/Employee/GetAllJobs')
            .then(response => response.json() as Promise<JobModel[]>)
            .then(data => {
                this.setState({ jobs: data });
            });
    }

    public render() {
        return <table className='table'>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Job title</th>
                    <th>Employment Date</th>
                    <th>Rate</th>
                    <th>Action</th>
                </tr>
            </thead>
            {this.renderBody()}
        </table>;
    }

    private renderBody(): JSX.Element {
        if (this.state && this.state.employees) {
            return <tbody>
                {this.state.employees.map(e => {
                    var job = this.state.jobs && this.state.jobs.filter(j => j.id == e.id)[0];
                    return <tr key={e.id}>
                        <td>{`${e.firstName} ${e.lastName}`}</td>
                        <td>{job && job.title}</td>
                        <td>{new Date(e.employmentDate).toLocaleDateString("en-US")}</td>
                        <td>{e.rate}$</td>
                        <td><a href="#">Delete</a></td>
                    </tr>
                }
                )}
            </tbody>
        }
        else {
            return <tbody></tbody>;
        }
    }
}

interface HomeState {
    employees?: EmployeeListModel[];
    jobs?: JobModel[]
}

interface EmployeeListModel {
    id: number;
    firstName: string;
    lastName: string;
    employmentDate: string;
    rate: number;
    jobId: number;
}

interface JobModel {
    id: number;
    title: string;
}

