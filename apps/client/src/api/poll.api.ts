import { API_URL } from './api.constants';
import { PollAdapter, toPoll } from '@/adapters/poll.adapter';
import { Poll, CreateVote } from '@/models/poll.model';

export async function getAllPolls(): Promise<Poll[]> {
  const response = await fetch(`${API_URL}/polls`);

  const data = (await response.json()) as PollAdapter[];

  return data.map((pa) => toPoll(pa));
}

export async function createVote(createPoll: CreateVote): Promise<string> {
  await fetch(`${API_URL}/polls/${createPoll.pollId}/votes`, {
    headers: {
      'Content-Type': 'application/json'
    },

    method: 'POST',
    body: JSON.stringify({
      optionId: createPoll.optionId,
      voterEmail: createPoll.voterEmail
    })
  });

  return 'Vote added Succesfully';
}
