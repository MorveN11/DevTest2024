import { API_URL } from './api.constants';
import { PollAdapter, toPoll } from '@/adapters/poll.adapter';
import { Poll } from '@/models/poll.model';

export async function getAllPolls(): Promise<Poll[]> {
  const response = await fetch(`${API_URL}/polls`);

  const data = (await response.json()) as PollAdapter[];

  return data.map((pa) => toPoll(pa));
}
